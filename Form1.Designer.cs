namespace article
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextErrorLinkLabel = new System.Windows.Forms.Label();
            this.RoundNum = new System.Windows.Forms.NumericUpDown();
            this.CalculateBtn = new System.Windows.Forms.Button();
            this.InfoCalcualateCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.syllablesInfoCountTextBox = new System.Windows.Forms.TextBox();
            this.lettersInfoCountTextBox = new System.Windows.Forms.TextBox();
            this.wordsInfoCountTextBox = new System.Windows.Forms.TextBox();
            this.sentencesInfoCountTextBox = new System.Windows.Forms.TextBox();
            this.SyllablesElementaryTextBox = new System.Windows.Forms.TextBox();
            this.LettersElementaryTextBox = new System.Windows.Forms.TextBox();
            this.WordsElementaryTextBox = new System.Windows.Forms.TextBox();
            this.SentencesElementaryTextBox = new System.Windows.Forms.TextBox();
            this.entropySyllablesTextBox = new System.Windows.Forms.TextBox();
            this.entropyLetterTextBox = new System.Windows.Forms.TextBox();
            this.entropyWordsTextBox = new System.Windows.Forms.TextBox();
            this.entropySentencesTextBox = new System.Windows.Forms.TextBox();
            this.countSyllablesUnicTextBox = new System.Windows.Forms.TextBox();
            this.countLetterUnicTextBox = new System.Windows.Forms.TextBox();
            this.countWordsUnicTextBox = new System.Windows.Forms.TextBox();
            this.countSentencesUnicTextBox = new System.Windows.Forms.TextBox();
            this.countSyllablesTextBox = new System.Windows.Forms.TextBox();
            this.countLetterTextBox = new System.Windows.Forms.TextBox();
            this.countWordsTextBox = new System.Windows.Forms.TextBox();
            this.countSentencesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderPathTextBox = new System.Windows.Forms.TextBox();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RoundNum)).BeginInit();
            this.SuspendLayout();
            // 
            // TextErrorLinkLabel
            // 
            this.TextErrorLinkLabel.AutoSize = true;
            this.TextErrorLinkLabel.Location = new System.Drawing.Point(116, 290);
            this.TextErrorLinkLabel.Name = "TextErrorLinkLabel";
            this.TextErrorLinkLabel.Size = new System.Drawing.Size(33, 13);
            this.TextErrorLinkLabel.TabIndex = 81;
            this.TextErrorLinkLabel.Text = "errors";
            // 
            // RoundNum
            // 
            this.RoundNum.Location = new System.Drawing.Point(377, 329);
            this.RoundNum.Name = "RoundNum";
            this.RoundNum.Size = new System.Drawing.Size(120, 20);
            this.RoundNum.TabIndex = 80;
            // 
            // CalculateBtn
            // 
            this.CalculateBtn.Location = new System.Drawing.Point(665, 5);
            this.CalculateBtn.Name = "CalculateBtn";
            this.CalculateBtn.Size = new System.Drawing.Size(518, 73);
            this.CalculateBtn.TabIndex = 79;
            this.CalculateBtn.Text = "button1";
            this.CalculateBtn.UseVisualStyleBackColor = true;
            this.CalculateBtn.Click += new System.EventHandler(this.CalculateBtn_Click);
            // 
            // InfoCalcualateCheckBox
            // 
            this.InfoCalcualateCheckBox.AutoSize = true;
            this.InfoCalcualateCheckBox.Location = new System.Drawing.Point(377, 370);
            this.InfoCalcualateCheckBox.Name = "InfoCalcualateCheckBox";
            this.InfoCalcualateCheckBox.Size = new System.Drawing.Size(80, 17);
            this.InfoCalcualateCheckBox.TabIndex = 78;
            this.InfoCalcualateCheckBox.Text = "checkBox1";
            this.InfoCalcualateCheckBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label11.Location = new System.Drawing.Point(6, 701);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 24);
            this.label11.TabIndex = 77;
            this.label11.Text = "Кол-во инф. на 1 ед.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.Location = new System.Drawing.Point(6, 640);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 24);
            this.label10.TabIndex = 76;
            this.label10.Text = "Ср. кол-во эл. симв.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.Location = new System.Drawing.Point(60, 588);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 24);
            this.label9.TabIndex = 75;
            this.label9.Text = "Энтропия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(60, 538);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 24);
            this.label8.TabIndex = 74;
            this.label8.Text = "Кол-во, уник";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(60, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 24);
            this.label7.TabIndex = 73;
            this.label7.Text = "Кол-во, всего";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(753, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 24);
            this.label6.TabIndex = 72;
            this.label6.Text = "Буквы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(558, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 71;
            this.label5.Text = "Слога";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(393, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 70;
            this.label4.Text = "Слова";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(206, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 69;
            this.label3.Text = "Предложения";
            // 
            // syllablesInfoCountTextBox
            // 
            this.syllablesInfoCountTextBox.Location = new System.Drawing.Point(734, 706);
            this.syllablesInfoCountTextBox.Name = "syllablesInfoCountTextBox";
            this.syllablesInfoCountTextBox.Size = new System.Drawing.Size(154, 20);
            this.syllablesInfoCountTextBox.TabIndex = 68;
            // 
            // lettersInfoCountTextBox
            // 
            this.lettersInfoCountTextBox.Location = new System.Drawing.Point(549, 706);
            this.lettersInfoCountTextBox.Name = "lettersInfoCountTextBox";
            this.lettersInfoCountTextBox.Size = new System.Drawing.Size(154, 20);
            this.lettersInfoCountTextBox.TabIndex = 67;
            // 
            // wordsInfoCountTextBox
            // 
            this.wordsInfoCountTextBox.Location = new System.Drawing.Point(374, 706);
            this.wordsInfoCountTextBox.Name = "wordsInfoCountTextBox";
            this.wordsInfoCountTextBox.Size = new System.Drawing.Size(154, 20);
            this.wordsInfoCountTextBox.TabIndex = 66;
            // 
            // sentencesInfoCountTextBox
            // 
            this.sentencesInfoCountTextBox.Location = new System.Drawing.Point(199, 706);
            this.sentencesInfoCountTextBox.Name = "sentencesInfoCountTextBox";
            this.sentencesInfoCountTextBox.Size = new System.Drawing.Size(154, 20);
            this.sentencesInfoCountTextBox.TabIndex = 65;
            // 
            // SyllablesElementaryTextBox
            // 
            this.SyllablesElementaryTextBox.Location = new System.Drawing.Point(734, 645);
            this.SyllablesElementaryTextBox.Name = "SyllablesElementaryTextBox";
            this.SyllablesElementaryTextBox.Size = new System.Drawing.Size(154, 20);
            this.SyllablesElementaryTextBox.TabIndex = 64;
            // 
            // LettersElementaryTextBox
            // 
            this.LettersElementaryTextBox.Location = new System.Drawing.Point(549, 645);
            this.LettersElementaryTextBox.Name = "LettersElementaryTextBox";
            this.LettersElementaryTextBox.Size = new System.Drawing.Size(154, 20);
            this.LettersElementaryTextBox.TabIndex = 63;
            // 
            // WordsElementaryTextBox
            // 
            this.WordsElementaryTextBox.Location = new System.Drawing.Point(374, 645);
            this.WordsElementaryTextBox.Name = "WordsElementaryTextBox";
            this.WordsElementaryTextBox.Size = new System.Drawing.Size(154, 20);
            this.WordsElementaryTextBox.TabIndex = 62;
            // 
            // SentencesElementaryTextBox
            // 
            this.SentencesElementaryTextBox.Location = new System.Drawing.Point(199, 645);
            this.SentencesElementaryTextBox.Name = "SentencesElementaryTextBox";
            this.SentencesElementaryTextBox.Size = new System.Drawing.Size(154, 20);
            this.SentencesElementaryTextBox.TabIndex = 61;
            // 
            // entropySyllablesTextBox
            // 
            this.entropySyllablesTextBox.Location = new System.Drawing.Point(734, 592);
            this.entropySyllablesTextBox.Name = "entropySyllablesTextBox";
            this.entropySyllablesTextBox.Size = new System.Drawing.Size(154, 20);
            this.entropySyllablesTextBox.TabIndex = 60;
            // 
            // entropyLetterTextBox
            // 
            this.entropyLetterTextBox.Location = new System.Drawing.Point(549, 592);
            this.entropyLetterTextBox.Name = "entropyLetterTextBox";
            this.entropyLetterTextBox.Size = new System.Drawing.Size(154, 20);
            this.entropyLetterTextBox.TabIndex = 59;
            // 
            // entropyWordsTextBox
            // 
            this.entropyWordsTextBox.Location = new System.Drawing.Point(374, 592);
            this.entropyWordsTextBox.Name = "entropyWordsTextBox";
            this.entropyWordsTextBox.Size = new System.Drawing.Size(154, 20);
            this.entropyWordsTextBox.TabIndex = 58;
            // 
            // entropySentencesTextBox
            // 
            this.entropySentencesTextBox.Location = new System.Drawing.Point(199, 592);
            this.entropySentencesTextBox.Name = "entropySentencesTextBox";
            this.entropySentencesTextBox.Size = new System.Drawing.Size(154, 20);
            this.entropySentencesTextBox.TabIndex = 57;
            // 
            // countSyllablesUnicTextBox
            // 
            this.countSyllablesUnicTextBox.Location = new System.Drawing.Point(734, 543);
            this.countSyllablesUnicTextBox.Name = "countSyllablesUnicTextBox";
            this.countSyllablesUnicTextBox.Size = new System.Drawing.Size(154, 20);
            this.countSyllablesUnicTextBox.TabIndex = 56;
            // 
            // countLetterUnicTextBox
            // 
            this.countLetterUnicTextBox.Location = new System.Drawing.Point(549, 543);
            this.countLetterUnicTextBox.Name = "countLetterUnicTextBox";
            this.countLetterUnicTextBox.Size = new System.Drawing.Size(154, 20);
            this.countLetterUnicTextBox.TabIndex = 55;
            // 
            // countWordsUnicTextBox
            // 
            this.countWordsUnicTextBox.Location = new System.Drawing.Point(374, 543);
            this.countWordsUnicTextBox.Name = "countWordsUnicTextBox";
            this.countWordsUnicTextBox.Size = new System.Drawing.Size(154, 20);
            this.countWordsUnicTextBox.TabIndex = 54;
            // 
            // countSentencesUnicTextBox
            // 
            this.countSentencesUnicTextBox.Location = new System.Drawing.Point(199, 543);
            this.countSentencesUnicTextBox.Name = "countSentencesUnicTextBox";
            this.countSentencesUnicTextBox.Size = new System.Drawing.Size(154, 20);
            this.countSentencesUnicTextBox.TabIndex = 53;
            // 
            // countSyllablesTextBox
            // 
            this.countSyllablesTextBox.Location = new System.Drawing.Point(734, 493);
            this.countSyllablesTextBox.Name = "countSyllablesTextBox";
            this.countSyllablesTextBox.Size = new System.Drawing.Size(154, 20);
            this.countSyllablesTextBox.TabIndex = 52;
            // 
            // countLetterTextBox
            // 
            this.countLetterTextBox.Location = new System.Drawing.Point(549, 493);
            this.countLetterTextBox.Name = "countLetterTextBox";
            this.countLetterTextBox.Size = new System.Drawing.Size(154, 20);
            this.countLetterTextBox.TabIndex = 51;
            // 
            // countWordsTextBox
            // 
            this.countWordsTextBox.Location = new System.Drawing.Point(374, 493);
            this.countWordsTextBox.Name = "countWordsTextBox";
            this.countWordsTextBox.Size = new System.Drawing.Size(154, 20);
            this.countWordsTextBox.TabIndex = 50;
            // 
            // countSentencesTextBox
            // 
            this.countSentencesTextBox.Location = new System.Drawing.Point(199, 493);
            this.countSentencesTextBox.Name = "countSentencesTextBox";
            this.countSentencesTextBox.Size = new System.Drawing.Size(154, 20);
            this.countSentencesTextBox.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "source";
            // 
            // FolderPathTextBox
            // 
            this.FolderPathTextBox.Location = new System.Drawing.Point(43, 162);
            this.FolderPathTextBox.Name = "FolderPathTextBox";
            this.FolderPathTextBox.Size = new System.Drawing.Size(496, 20);
            this.FolderPathTextBox.TabIndex = 46;
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(43, 35);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(497, 20);
            this.FilePathTextBox.TabIndex = 45;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(562, 98);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(648, 350);
            this.resultTextBox.TabIndex = 44;
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.Location = new System.Drawing.Point(43, 195);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenFolder.TabIndex = 43;
            this.ButtonOpenFolder.Text = "source";
            this.ButtonOpenFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(43, 69);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenFile.TabIndex = 42;
            this.ButtonOpenFile.Text = "faile";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 748);
            this.Controls.Add(this.TextErrorLinkLabel);
            this.Controls.Add(this.RoundNum);
            this.Controls.Add(this.CalculateBtn);
            this.Controls.Add(this.InfoCalcualateCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.syllablesInfoCountTextBox);
            this.Controls.Add(this.lettersInfoCountTextBox);
            this.Controls.Add(this.wordsInfoCountTextBox);
            this.Controls.Add(this.sentencesInfoCountTextBox);
            this.Controls.Add(this.SyllablesElementaryTextBox);
            this.Controls.Add(this.LettersElementaryTextBox);
            this.Controls.Add(this.WordsElementaryTextBox);
            this.Controls.Add(this.SentencesElementaryTextBox);
            this.Controls.Add(this.entropySyllablesTextBox);
            this.Controls.Add(this.entropyLetterTextBox);
            this.Controls.Add(this.entropyWordsTextBox);
            this.Controls.Add(this.entropySentencesTextBox);
            this.Controls.Add(this.countSyllablesUnicTextBox);
            this.Controls.Add(this.countLetterUnicTextBox);
            this.Controls.Add(this.countWordsUnicTextBox);
            this.Controls.Add(this.countSentencesUnicTextBox);
            this.Controls.Add(this.countSyllablesTextBox);
            this.Controls.Add(this.countLetterTextBox);
            this.Controls.Add(this.countWordsTextBox);
            this.Controls.Add(this.countSentencesTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FolderPathTextBox);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.ButtonOpenFolder);
            this.Controls.Add(this.ButtonOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.RoundNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TextErrorLinkLabel;
        private System.Windows.Forms.NumericUpDown RoundNum;
        private System.Windows.Forms.Button CalculateBtn;
        private System.Windows.Forms.CheckBox InfoCalcualateCheckBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox syllablesInfoCountTextBox;
        private System.Windows.Forms.TextBox lettersInfoCountTextBox;
        private System.Windows.Forms.TextBox wordsInfoCountTextBox;
        private System.Windows.Forms.TextBox sentencesInfoCountTextBox;
        private System.Windows.Forms.TextBox SyllablesElementaryTextBox;
        private System.Windows.Forms.TextBox LettersElementaryTextBox;
        private System.Windows.Forms.TextBox WordsElementaryTextBox;
        private System.Windows.Forms.TextBox SentencesElementaryTextBox;
        private System.Windows.Forms.TextBox entropySyllablesTextBox;
        private System.Windows.Forms.TextBox entropyLetterTextBox;
        private System.Windows.Forms.TextBox entropyWordsTextBox;
        private System.Windows.Forms.TextBox entropySentencesTextBox;
        private System.Windows.Forms.TextBox countSyllablesUnicTextBox;
        private System.Windows.Forms.TextBox countLetterUnicTextBox;
        private System.Windows.Forms.TextBox countWordsUnicTextBox;
        private System.Windows.Forms.TextBox countSentencesUnicTextBox;
        private System.Windows.Forms.TextBox countSyllablesTextBox;
        private System.Windows.Forms.TextBox countLetterTextBox;
        private System.Windows.Forms.TextBox countWordsTextBox;
        private System.Windows.Forms.TextBox countSentencesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderPathTextBox;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button ButtonOpenFolder;
        private System.Windows.Forms.Button ButtonOpenFile;
    }
}

