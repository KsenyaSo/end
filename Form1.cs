using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace article
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string textFilePath;
        private static string text;
        private static string folderPath;
        private static string folderPathDialog;
        private static string dateTime;

        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static readonly HashSet<char> Glas = new HashSet<char>("aeiouy"),
            Soglas = new HashSet<char>("bcdfghjklmnpqrstvwxz");

        private static readonly char[] separator = new char[] { ',', '.', '?', '-', '!', '—', ';', ' ', ':',
            '\r', '\n', '\t', '\a', '\b', '\f', '\v', '\'', '\"', '«', '»',
            '`', '~', '>', '<', '(', ')', '=', '+', '*', '&', '^', '%', '$', '#', '@', '№', '/', '\\', '|',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};

        private static readonly List<string> stopWords = new List<string> {
            "a", "b", "c", "d", "e", "f", "g", "h", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };
        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textFilePath))
            {
                resultTextBox.Text = "Необходимо указать файл с текстом";
                return;
            }
            if (string.IsNullOrEmpty(folderPathDialog) || !Directory.Exists(folderPathDialog))
            {
                resultTextBox.Text = "Путь к папке не найден. Необходимо указать папку для записи результатов";
                return;
            }

            dateTime = DateTime.Now.ToString().Replace('/', '.').Replace(':', '.');

            using (StreamReader streamReader = new StreamReader(textFilePath, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd().Trim().Replace("\r\n", " ");
            }

            resultTextBox.Text = "Символов в исходном тексте: " + text.Length + "\r\n\r\n";

            // Деление текста на предложения
            string[] sentencesSplit = Regex.Split(text, @"(?<=[\.!\?{:\r}])\s+");
            int sc = sentencesSplit.Count();
            List<string> sentences = new List<string>();
            for (int i = 0; i < sc; i++)
            {
                string firstSymbol = sentencesSplit[i][0].ToString();
                if (firstSymbol == firstSymbol.ToLower() && i > 0 && alphabet.Contains(firstSymbol.ToLower()))
                {
                    string lastCentences = sentences.Last();
                    sentences.RemoveAt(sentences.Count - 1);
                    sentences.Add(lastCentences + " " + sentencesSplit[i]);
                    continue;
                }
                sentences.Add(sentencesSplit[i]);
            }

            //Вчетрчаемость предложений
            var sentencesCountDict = sentences.GroupBy(el => el).ToDictionary(el => el.Key, el => el.Count()).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            //Частота встречамости предложений
            var probabilitySentences = GetProbability(sentencesCountDict, sentences.Count).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            //Энтропия предложений
            var entropySentences = GetEntropy(probabilitySentences);

            countSentencesTextBox.Text = sentences.Count.ToString();
            entropySentencesTextBox.Text = String.Format("{0:f4}", entropySentences);
            countSentencesUnicTextBox.Text = sentencesCountDict.Count.ToString();


            resultTextBox.Text += "Шаг 1. Токенизация. Удаление лишних символов\r\n";

            var words = text.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

            resultTextBox.Text += "Символов: " + GetLettersCountInText(words) + "\r\n";
            resultTextBox.Text += "Слов: " + words.Count + "\r\n\r\n";

            resultTextBox.Text += "Шаг 2. Стоп-лист. Удаление слов из стоп листа и слов, содержащих символы не русского алфавита\r\n";

            words.RemoveAll(word => stopWords.Any(stopWord => word == stopWord) || CheckLetter(word));
            if (words.Count == 0)
            {
                resultTextBox.Text += "Программа остановлена, количество слов равно 0\r\n";
                return;
            }

            resultTextBox.Text += "Слов: " + words.Count + "\r\n\r\n";

            //Вчетречаемость слов + частота
            var wordsCountDict = words.GroupBy(el => el).ToDictionary(el => el.Key, el => el.Count()).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var probabilityWords = GetProbability(wordsCountDict, words.Count).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            //Энтропия слов
            var entropyWords = GetEntropy(probabilityWords);
            countWordsTextBox.Text = words.Count.ToString();
            countWordsUnicTextBox.Text = wordsCountDict.Count.ToString();
            entropyWordsTextBox.Text = String.Format("{0:f4}", entropyWords);

            resultTextBox.Text += "Шаг 3. Деление на слоги\r\n";

            var syllables = new List<string>();
            words.ForEach(word => GetSyllables(word));
            resultTextBox.Text += "Слогов: " + syllables.Count + "\r\n\r\n";

            resultTextBox.Text += "Шаг 4. Вычисления\r\n";

            int lettersCountInText = GetLettersCountInText(words);
            var letterCountDict = GetLetterCount(words).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var probabilityLetter = GetProbability(letterCountDict, lettersCountInText).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var entropyLetter = GetEntropy(probabilityLetter);

            countLetterTextBox.Text = lettersCountInText.ToString();
            countLetterUnicTextBox.Text = letterCountDict.Count.ToString();
            entropyLetterTextBox.Text = String.Format("{0:f4}", entropyLetter);

            var syllablesCountDict = syllables.GroupBy(el => el).ToDictionary(el => el.Key, el => el.Count()).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var probabilitySyllables = GetProbability(syllablesCountDict, syllables.Count).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var entropySyllables = GetEntropy(probabilitySyllables);

            countSyllablesTextBox.Text = syllables.Count.ToString();
            countSyllablesUnicTextBox.Text = syllablesCountDict.Count.ToString();
            entropySyllablesTextBox.Text = String.Format("{0:f4}", entropySyllables);

            //Фано
            string[] sentencesFano = new string[sentencesCountDict.Count];
            string[] wordsFano = new string[wordsCountDict.Count];
            string[] syllablesFano = new string[syllablesCountDict.Count];
            string[] lettersFano = new string[letterCountDict.Count];

            Fano(0, sentencesCountDict.Count - 1, sentencesFano, probabilitySentences);
            Fano(0, wordsCountDict.Count - 1, wordsFano, probabilityWords);
            Fano(0, syllablesCountDict.Count - 1, syllablesFano, probabilitySyllables);
            Fano(0, letterCountDict.Count - 1, lettersFano, probabilityLetter);

            double sentencesFanoElementaryCount = CountElementaryCharOnOneEncodeChar(sentencesFano, probabilitySentences);
            double wordsFanoElementaryCount = CountElementaryCharOnOneEncodeChar(wordsFano, probabilityWords);
            double syllablesFanoElementaryCount = CountElementaryCharOnOneEncodeChar(syllablesFano, probabilitySyllables);
            double lettersFanoElementaryCount = CountElementaryCharOnOneEncodeChar(lettersFano, probabilityLetter);

            SentencesElementaryTextBox.Text = String.Format("{0:f4}", sentencesFanoElementaryCount);
            WordsElementaryTextBox.Text = String.Format("{0:f4}", wordsFanoElementaryCount);
            SyllablesElementaryTextBox.Text = String.Format("{0:f4}", syllablesFanoElementaryCount);
            LettersElementaryTextBox.Text = String.Format("{0:f4}", lettersFanoElementaryCount);

            //Кол-в информации на 1 симол
            double sentencesInfoCount = GetInfoCount(entropySentences, sentencesFanoElementaryCount);
            double wordsInfoCount = GetInfoCount(entropyWords, wordsFanoElementaryCount);
            double syllablesInfoCount = GetInfoCount(entropySyllables, syllablesFanoElementaryCount);
            double lettersInfoCount = GetInfoCount(entropyLetter, lettersFanoElementaryCount);

            sentencesInfoCountTextBox.Text = String.Format("{0:f4}", sentencesInfoCount);
            wordsInfoCountTextBox.Text = String.Format("{0:f4}", wordsInfoCount);
            syllablesInfoCountTextBox.Text = String.Format("{0:f4}", syllablesInfoCount);
            lettersInfoCountTextBox.Text = String.Format("{0:f4}", lettersInfoCount);

            Directory.CreateDirectory(folderPathDialog + "\\" + dateTime);
            folderPath = folderPathDialog + "\\" + dateTime;

            WriteToFileCVS("Предложения", sentencesCountDict, probabilitySentences, sentences.Count, entropySentences, sentencesFano, sentencesFanoElementaryCount, sentencesInfoCount);
            WriteToFileCVS("Слова", wordsCountDict, probabilityWords, words.Count, entropyWords, wordsFano, wordsFanoElementaryCount, wordsInfoCount);
            WriteToFileCVS("Слоги", syllablesCountDict, probabilitySyllables, syllables.Count, entropySyllables, syllablesFano, syllablesFanoElementaryCount, syllablesInfoCount);
            WriteToFileCVS("Буквы", letterCountDict, probabilityLetter, lettersCountInText, entropyLetter, lettersFano, lettersFanoElementaryCount, lettersInfoCount);

            resultTextBox.Text += "Количество символов, всего в тексте: \r\n" +
               "    Предложения    " + countSentencesTextBox.Text + "\r\n" +
               "    Слова          " + countWordsTextBox.Text + "\r\n" +
               "    Слоги          " + countSyllablesTextBox.Text + "\r\n" +
               "    Буквы          " + countLetterTextBox.Text + "\r\n\r\n";

            resultTextBox.Text += "Количество уникальных символов: \r\n" +
                "    Предложения    " + countSentencesUnicTextBox.Text + "\r\n" +
                "    Слова          " + countWordsUnicTextBox.Text + "\r\n" +
                "    Слоги          " + countSyllablesUnicTextBox.Text + "\r\n" +
                "    Буквы          " + countLetterUnicTextBox.Text + "\r\n\r\n";

            resultTextBox.Text += "Энтропия: \r\n" +
                "    Предложения    " + entropySentences + "\r\n" +
                "    Слова          " + entropyWords + "\r\n" +
                "    Слоги          " + entropySyllables + "\r\n" +
                "    Буквы          " + entropyLetter + "\r\n\r\n";

            resultTextBox.Text += "Среднее количество элементарных символов на 1 символ текста: \r\n" +
                "    Предложения    " + sentencesFanoElementaryCount + "\r\n" +
                "    Слова          " + wordsFanoElementaryCount + "\r\n" +
                "    Слоги          " + syllablesFanoElementaryCount + "\r\n" +
                "    Буквы          " + lettersFanoElementaryCount + "\r\n\r\n";

            resultTextBox.Text += "Количество информации на один элементарный символ: \r\n"+
                "    Предложения    " + sentencesInfoCount + "\r\n" +
                "    Слова          " + wordsInfoCount + "\r\n" +
                "    Слоги          " + syllablesInfoCount + "\r\n" +
                "    Буквы          " + lettersInfoCount + "\r\n\r\n";
            resultTextBox.Text += "Завершено";

            WriteToFile("Вывод", "Путь к файлу: " + textFilePath + "\r\n" + resultTextBox.Text);

            if (InfoCalcualateCheckBox.Checked)
            {
                var infoGraph = new List<GraphInfo>();
                try
                {
                    int n = (int)RoundNum.Value; //количество отрезков данных
                    if (sentences.Count >= 2 * n)
                    {
                        int countPart = sentences.Count / n;
                        for (int i = 1; i < n; i++)
                        {
                            int countElement = countPart * i;
                            var sentencesPart = new string[countElement];
                            sentences.CopyTo(0, sentencesPart, 0, countElement);
                            infoGraph.Add(InfoForGraph(sentencesPart, countElement));
                        }
                        infoGraph.Add(new GraphInfo()
                        {
                            CharTextCount = text.Length,
                            InfoCountSentences = sentencesInfoCount,
                            CountSentences = sentences.Count,
                            InfoCountWords = wordsInfoCount,
                            CountWords = words.Count,
                            InfoCountSyllables = syllablesInfoCount,
                            CountSyllables = syllables.Count,
                            InfoCountLetters = lettersInfoCount,
                            CountLetters = lettersCountInText
                        });
                    }
                    else
                        resultTextBox.Text += "\r\n\r\nДанные для графиков не рассчитывались из-за малого количество вводной информации";
                }
                catch
                {
                    resultTextBox.Text += "\r\n\r\nПри расчитывании данных для графиков произошла ошибка - не все части удалось посчитать";
                    if (infoGraph.Count > 0) resultTextBox.Text += "\r\nВ выходной файл будут записаны данные для тех частей, которые удалось посчитать";
                }

                if (infoGraph.Count > 0)
                    WriteGraphInfo(infoGraph);
            }
        }

            private GraphInfo InfoForGraph(string[] sentences, int sentencesCount)
        {
            string text = "";
            foreach (var s in sentences)
            {
                text += s + " ";
            }
            //Вcтречаемость предложений
            var sentencesCountDict = sentences.GroupBy(el => el).ToDictionary(el => el.Key, el => el.Count()).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            //Частота встречамости предложений
            var probabilitySentences = GetProbability(sentencesCountDict, sentencesCount).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            //Энтропия предложений
            var entropySentences = GetEntropy(probabilitySentences);

            var words = text.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

            words.RemoveAll(word => stopWords.Any(stopWord => word == stopWord) || CheckLetter(word));
            if (words.Count == 0)
                throw new Exception();

            //Вчетречаемость слов + частота
            var wordsCountDict = words.GroupBy(el => el).ToDictionary(el => el.Key, el => el.Count()).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var probabilityWords = GetProbability(wordsCountDict, words.Count).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            //Энтропия слов
            var entropyWords = GetEntropy(probabilityWords);

            //Слоги
            var syllables = new List<string>();
            //words.ForEach(word => GetSyllables(word).ToList().ForEach(el => syllables.Add(el)));

            int lettersCountInText = GetLettersCountInText(words);
            var letterCountDict = GetLetterCount(words).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var probabilityLetter = GetProbability(letterCountDict, lettersCountInText).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var entropyLetter = GetEntropy(probabilityLetter);

            var syllablesCountDict = syllables.GroupBy(el => el).ToDictionary(el => el.Key, el => el.Count()).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var probabilitySyllables = GetProbability(syllablesCountDict, syllables.Count).OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var entropySyllables = GetEntropy(probabilitySyllables);

            //Фано
            string[] sentencesFano = new string[sentencesCountDict.Count];
            string[] wordsFano = new string[wordsCountDict.Count];
            string[] syllablesFano = new string[syllablesCountDict.Count];
            string[] lettersFano = new string[letterCountDict.Count];

            Fano(0, sentencesCountDict.Count - 1, sentencesFano, probabilitySentences);
            Fano(0, wordsCountDict.Count - 1, wordsFano, probabilityWords);
            Fano(0, syllablesCountDict.Count - 1, syllablesFano, probabilitySyllables);
            Fano(0, letterCountDict.Count - 1, lettersFano, probabilityLetter);

            double sentencesFanoElementaryCount = CountElementaryCharOnOneEncodeChar(sentencesFano, probabilitySentences);
            double wordsFanoElementaryCount = CountElementaryCharOnOneEncodeChar(wordsFano, probabilityWords);
            double syllablesFanoElementaryCount = CountElementaryCharOnOneEncodeChar(syllablesFano, probabilitySyllables);
            double lettersFanoElementaryCount = CountElementaryCharOnOneEncodeChar(lettersFano, probabilityLetter);
            //Кол-в информации на 1 симол
            double sentencesInfoCount = GetInfoCount(entropySentences, sentencesFanoElementaryCount);
            double wordsInfoCount = GetInfoCount(entropyWords, wordsFanoElementaryCount);
            double syllablesInfoCount = GetInfoCount(entropySyllables, syllablesFanoElementaryCount);
            double lettersInfoCount = GetInfoCount(entropyLetter, lettersFanoElementaryCount);

            return new GraphInfo()
            {
                CharTextCount = text.Length,
                InfoCountSentences = sentencesInfoCount,
                CountSentences = sentencesCount,
                InfoCountWords = wordsInfoCount,
                CountWords = words.Count,
                InfoCountSyllables = syllablesInfoCount,
                CountSyllables = syllables.Count,
                InfoCountLetters = lettersInfoCount,
                CountLetters = lettersCountInText
            };
        }

        private double GetInfoCountHartly(int count, int unic)
        {
            return count*Math.Log(unic, 2);
        }

        private double GetInfoCount(double entropy, double elementaryCount)
        {
            return entropy / elementaryCount;
        }

        private double CountElementaryCharOnOneEncodeChar<T>(string[] fano, Dictionary<T, double> dict)
        {
            double sum = 0;
            for (int i = 0; i < dict.Count; i++)
                sum += dict.ElementAt(i).Value * fano[i].Length;
            return sum;
        }

        private string Encode(List<string> textList, Dictionary<string, string> fanoDict)
        {
            string result = "";
            //fanoDict key - предложение/слово и т.п. value - fano
            textList.ForEach(el => result += fanoDict[el] + " ");
            return result;
        }

        private string EncodeLetters(List<string> textList, Dictionary<char, string> fanoDict)
        {
            string result = "";
            //fanoDict key - предложение/слово и т.п. value - fano
            foreach (var word in textList)
                foreach (var letter in word)
                    result += fanoDict[letter] + " ";
            return result;
        }

        private Dictionary<string, string> FanoDict(string[] fano, Dictionary<string, double> dict)
        {
            var newDict = new Dictionary<string, string> { };
            for (int i = 0; i < dict.Count; i++)
                newDict.Add(dict.ElementAt(i).Key, fano[i]);
            return newDict;
        }

        private Dictionary<char, string> FanoDict(string[] fano, Dictionary<char, double> dict)
        {
            var newDict = new Dictionary<char, string> { };
            for (int i = 0; i < dict.Count; i++)
                newDict.Add(dict.ElementAt(i).Key, fano[i]);
            return newDict;
        }

        private void WriteToFileCVS<T>(string filename, Dictionary<T, int> dict, Dictionary<T, double> pdict, int count, double entropy, string[] fano, double elementaryCount, double infoCount)
        {
            string path;
            path = folderPath + "\\" + filename + " " + dateTime + ".csv";
            var mem = new MemoryStream();
            var writer = new StreamWriter(path, false, Encoding.UTF8);
            var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteField(filename);
            csvWriter.WriteField("Встречаемость");
            csvWriter.WriteField("Вероятность");
            csvWriter.WriteField("Фано");
            csvWriter.WriteField("Количество всего");
            csvWriter.WriteField(count);
            csvWriter.WriteField("Энтропия");
            csvWriter.WriteField(entropy);
            csvWriter.WriteField("Ср. кол-во эл. симв.");
            csvWriter.WriteField(elementaryCount);
            csvWriter.WriteField("Кол-во инф. на 1 симв.");
            csvWriter.WriteField(infoCount);
            csvWriter.NextRecord();

            for (int i = 0; i < dict.Count; i++)
            {
                csvWriter.WriteField(dict.ElementAt(i).Key);
                csvWriter.WriteField(dict.ElementAt(i).Value);
                csvWriter.WriteField(pdict.ElementAt(i).Value);
                csvWriter.WriteField("'" + fano[i]);
                csvWriter.NextRecord();
            }

            writer.Flush();
            writer.Close();
        }
        private void WriteToFile(string fileName, string text)
        {
            string path = folderPath + "\\" + fileName + " " + dateTime + ".txt";

            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }
        private void WriteGraphInfo(List<GraphInfo> infoGraph)
        {
            string path;
            string filename = "Информация для графиков";
            path = folderPath + "\\" + filename + " " + dateTime + ".csv";
            var mem = new MemoryStream();
            var writer = new StreamWriter(path, false, Encoding.UTF8);
            var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteField(filename);
            csvWriter.NextRecord();
            csvWriter.NextRecord();

            csvWriter.WriteField("");
            csvWriter.WriteField("Символов в тексте");
            csvWriter.WriteField("Предложений");
            csvWriter.WriteField("Слов");
            csvWriter.WriteField("Слогов");
            csvWriter.WriteField("Букв");
            csvWriter.NextRecord();

            foreach (var ig in infoGraph)
            {
                csvWriter.WriteField("");
                csvWriter.WriteField(ig.CharTextCount);
                csvWriter.WriteField(ig.InfoCountSentences);
                csvWriter.WriteField(ig.InfoCountWords);
                csvWriter.WriteField(ig.InfoCountSyllables);
                csvWriter.WriteField(ig.InfoCountLetters);
                csvWriter.NextRecord();
            }

            csvWriter.NextRecord();
            csvWriter.WriteField("Доп. информация: количество элементов в частях текста");
            csvWriter.NextRecord();
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("Предложений");
            csvWriter.WriteField("Слов");
            csvWriter.WriteField("Слогов");
            csvWriter.WriteField("Букв");
            csvWriter.NextRecord();

            foreach (var ig in infoGraph)
            {
                csvWriter.WriteField("");
                csvWriter.WriteField("");
                csvWriter.WriteField(ig.CountSentences);
                csvWriter.WriteField(ig.CountWords);
                csvWriter.WriteField(ig.CountSyllables);
                csvWriter.WriteField(ig.CountLetters);
                csvWriter.NextRecord();
            }

            writer.Flush();
            writer.Close();
        }

        private bool CheckLetter(string word)
        {
            foreach (char letter in word)
            {
                if (!alphabet.Contains(letter))
                    return true;
            }
            return false;
        }

        private void WriteDict<T, TE>(string context, Dictionary<T, TE> dict)
        {
            resultTextBox.Text += context + "\r\n";
            foreach (KeyValuePair<T, TE> keyValue in dict)
            {
                resultTextBox.Text += keyValue.Key + " - " + keyValue.Value + "\r\n";
            }
            resultTextBox.Text += "\r\n";
        }

        private string WriteTextDict<T, TE>(string title, Dictionary<T, TE> dict)
        {
            string text = title;
            foreach (KeyValuePair<T, TE> keyValue in dict)
            {
                text += keyValue.Key + " - " + keyValue.Value + "\r\n";
            }
            return text;
        }

        private void WriteList(List<string> context, string separator)
        {
            context.ForEach(el => resultTextBox.Text += el + separator);
            resultTextBox.Text += "\r\n";
        }

        private string WriteTextList(List<string> context, string separator)
        {
            string text = "";
            context.ForEach(el => text += el + separator);
            return text;
        }

        private int GetLettersCountInText(List<string> words)
        {
            int count = 0;
            words.ForEach(el => count += el.Length);
            return count;
        }

        private Dictionary<char, int> GetLetterCount(List<string> words)
        {
            Dictionary<char, int> letterCountDict = new Dictionary<char, int> { ['a'] = 0, ['b'] = 0, ['c'] = 0, ['d'] = 0, ['f'] = 0, ['x']=0, ['e'] = 0, ['g'] = 0, ['h'] = 0, ['i'] = 0, ['j'] = 0, ['k'] = 0, ['l'] = 0, ['m'] = 0, ['n'] = 0, ['o'] = 0, ['p'] = 0, ['q'] = 0, ['r'] = 0, ['s'] = 0, ['t'] = 0, ['u'] = 0, ['v'] = 0, ['y'] = 0, ['z'] = 0, ['w']=0 };
            foreach (string word in words)
            {
                foreach (char w in word)
                {
                    letterCountDict[w] += 1;
                }
            }
            return letterCountDict.Where(item => item.Value != 0).ToDictionary(item => item.Key, item => item.Value);
        }

        private static Dictionary<string, double> GetProbability(Dictionary<string, int> dict, int count)
        {
            var result = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> keyValue in dict)
            {
                result[keyValue.Key] = (double)keyValue.Value / count;
            }
            return result;
        }
        private static Dictionary<char, double> GetProbability(Dictionary<char, int> dict, int count)
        {
            var result = new Dictionary<char, double>();
            foreach (KeyValuePair<char, int> keyValue in dict)
            {
                result[keyValue.Key] = (double)keyValue.Value / count;
            }
            return result;
        }
        private static double GetEntropy<T>(Dictionary<T, double> dict)
        {
            double sum = 0;
            foreach (KeyValuePair<T, double> keyValue in dict)
            {
                if (keyValue.Value != 0)
                    sum += keyValue.Value * Math.Log(keyValue.Value, 2);
            }
            return -sum;
        }

        private static int GetSyllables(string word)
        {
            int i = 0;
            int count = 0;
            if  (Glas.Contains(word[i])) count+=1;
            for (i=1; i<word.Length; i++)
            {
                if (Glas.Contains(word[i]) && Soglas.Contains(word[i-1]))
                    count++;
            }
            if (word.EndsWith("e")) count--;
            /*if (word.Length>2)
            {
                string t = word.Substring(word.Length-3);
                t=t.Substring(0, t.Length-2);
                char b = Convert.ToChar(t);
            }*/
            if (word.EndsWith("le") && word.Length>2)
            {
                    string t = word.Substring(word.Length-3);
                    t=t.Substring(0, t.Length-2);
                    char b = Convert.ToChar(t);
                    if (Soglas.Contains(b)) count++;
            }
            if (count==0) count++;
            return count;
        }

        private int GlasLeft(string input, int i)
        {
            int count = 0;
            for (int j = i; j < input.Length; j++)
                if (Glas.Contains(input[j]))
                    count++;
            return count;
        }
        public void Fano(int L, int R, string[] Res, Dictionary<string, double> dict)
        {
            int n;
            if (L < R)
            {
                n = Delenie_Posledovatelnosty(L, R, dict);
                for (int i = L; i <= R; i++)
                {
                    if (i <= n)
                    {
                        Res[i] += Convert.ToByte(0);
                    }
                    else
                    {
                        Res[i] += Convert.ToByte(1);
                    }
                }
                Fano(L, n, Res, dict);
                Fano(n + 1, R, Res, dict);
            }
        }
        public int Delenie_Posledovatelnosty(int L, int R, Dictionary<string, double> P1)
        {

            double even1 = 0;
            for (int i = L; i <= R - 1; i++)
            {
                even1 = even1 + P1.ElementAt(i).Value;
            }

            double even2 = P1.ElementAt(R).Value;
            int m = R;
            while (even1 >= even2)
            {
                m = m - 1;
                even1 = even1 - P1.ElementAt(m).Value;
                even2 = even2 + P1.ElementAt(m).Value;
            }
            return m;
        }

        private void RoundNum_ValueChanged(object sender, EventArgs e)
        {
            if (InfoCalcualateCheckBox.Checked && RoundNum.Value > 7)
            {
                TextErrorLinkLabel.Visible = true;
            }
            else
            {
                TextErrorLinkLabel.Visible = false;
            }
        }

        public void Fano(int Left, int Right, string[] Res, Dictionary<char, double> dict)
        {
            int n;
            if (Left < Right)
            {
                n = Delenie_Posledovatelnosty(Left, Right, dict);
                for (int i = Left; i <= Right; i++)
                {
                    if (i <= n)
                    {
                        Res[i] += '0';
                    }
                    else
                    {
                        Res[i] += '1';
                    }
                }
                Fano(Left, n, Res, dict);
                Fano(n + 1, Right, Res, dict);
            }
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
                textFilePath = openFileDialog.FileName;
            }
            ClearInfo();
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FolderPathTextBox.Text = folderBrowserDialog.SelectedPath;
                folderPathDialog = folderBrowserDialog.SelectedPath;
            }
            ClearInfo();
        }

        public int Delenie_Posledovatelnosty(int Left, int Right, Dictionary<char, double> P1)
        {
            double even1 = 0;
            for (int i = Left; i <= Right - 1; i++)
            {
                even1 = even1 + P1.ElementAt(i).Value;
            }

            double even2 = P1.ElementAt(Right).Value;
            int n = Right;
            while (even1 >= even2)
            {
                n = n - 1;
                even1 = even1 - P1.ElementAt(n).Value;
                even2 = even2 + P1.ElementAt(n).Value;
            }
            return n;
        }
        private void ClearInfo()
        {
            resultTextBox.Text = "";

            countSentencesTextBox.Text = "";
            countWordsTextBox.Text = "";
            countSyllablesTextBox.Text = "";
            countLetterTextBox.Text = "";

            countSentencesUnicTextBox.Text = "";
            countWordsUnicTextBox.Text = "";
            countSyllablesUnicTextBox.Text = "";
            countLetterUnicTextBox.Text = "";

            sentencesInfoCountTextBox.Text = "";
            wordsInfoCountTextBox.Text = "";
            syllablesInfoCountTextBox.Text = "";
            lettersInfoCountTextBox.Text = "";

            SentencesElementaryTextBox.Text = "";
            WordsElementaryTextBox.Text = "";
            SyllablesElementaryTextBox.Text = "";
            LettersElementaryTextBox.Text = "";

            countSentencesTextBox.Text = "";
            entropySentencesTextBox.Text = "";
            countSentencesUnicTextBox.Text = "";

            countWordsTextBox.Text = "";
            countWordsUnicTextBox.Text = "";
            entropyWordsTextBox.Text = "";

            countLetterTextBox.Text = "";
            countLetterUnicTextBox.Text = "";
            entropyLetterTextBox.Text = "";

            countSyllablesTextBox.Text = "";
            countSyllablesUnicTextBox.Text = "";
            entropySyllablesTextBox.Text = "";
        }
    }
}
