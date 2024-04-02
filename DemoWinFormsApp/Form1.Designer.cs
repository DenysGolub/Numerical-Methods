namespace DemoWinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            function_text = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            epsilon = new RichTextBox();
            answers = new RichTextBox();
            radioChord = new RadioButton();
            radioSecant = new RadioButton();
            radioPF = new RadioButton();
            radioSI = new RadioButton();
            radioNewton = new RadioButton();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            label1 = new Label();
            b_interval = new RichTextBox();
            a_interval = new RichTextBox();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(6, -14);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(797, 698);
            formsPlot1.TabIndex = 0;
            // 
            // function_text
            // 
            function_text.Font = new Font("Segoe UI", 12F);
            function_text.Location = new Point(817, 83);
            function_text.Name = "function_text";
            function_text.Size = new Size(204, 35);
            function_text.TabIndex = 2;
            function_text.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(767, 137);
            label2.Name = "label2";
            label2.Size = new Size(36, 28);
            label2.TabIndex = 1;
            label2.Text = "a=";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(867, 137);
            label3.Name = "label3";
            label3.Size = new Size(38, 28);
            label3.TabIndex = 1;
            label3.Text = "b=";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(984, 137);
            label4.Name = "label4";
            label4.Size = new Size(35, 28);
            label4.TabIndex = 1;
            label4.Text = "ε=";
            // 
            // epsilon
            // 
            epsilon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            epsilon.Location = new Point(1017, 134);
            epsilon.Name = "epsilon";
            epsilon.Size = new Size(117, 34);
            epsilon.TabIndex = 3;
            epsilon.Text = "0.01";
            // 
            // answers
            // 
            answers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            answers.Location = new Point(767, 361);
            answers.Name = "answers";
            answers.Size = new Size(356, 294);
            answers.TabIndex = 4;
            answers.Text = "";
            // 
            // radioChord
            // 
            radioChord.AutoSize = true;
            radioChord.Checked = true;
            radioChord.Font = new Font("Segoe UI", 12F);
            radioChord.Location = new Point(767, 198);
            radioChord.Name = "radioChord";
            radioChord.Size = new Size(80, 32);
            radioChord.TabIndex = 5;
            radioChord.TabStop = true;
            radioChord.Text = "Хорд";
            radioChord.UseVisualStyleBackColor = true;
            // 
            // radioSecant
            // 
            radioSecant.AutoSize = true;
            radioSecant.Font = new Font("Segoe UI", 12F);
            radioSecant.Location = new Point(883, 198);
            radioSecant.Name = "radioSecant";
            radioSecant.Size = new Size(94, 32);
            radioSecant.TabIndex = 5;
            radioSecant.Text = "Січних";
            radioSecant.UseVisualStyleBackColor = true;
            // 
            // radioPF
            // 
            radioPF.AutoSize = true;
            radioPF.Font = new Font("Segoe UI", 12F);
            radioPF.Location = new Point(1006, 188);
            radioPF.Name = "radioPF";
            radioPF.Size = new Size(144, 60);
            radioPF.TabIndex = 5;
            radioPF.Text = "Половинне \r\nділення";
            radioPF.UseVisualStyleBackColor = true;
            radioPF.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioSI
            // 
            radioSI.AutoSize = true;
            radioSI.Font = new Font("Segoe UI", 12F);
            radioSI.Location = new Point(767, 228);
            radioSI.Name = "radioSI";
            radioSI.Size = new Size(100, 60);
            radioSI.TabIndex = 5;
            radioSI.Text = "Прості \r\nітерації";
            radioSI.UseVisualStyleBackColor = true;
            // 
            // radioNewton
            // 
            radioNewton.AutoSize = true;
            radioNewton.Font = new Font("Segoe UI", 12F);
            radioNewton.Location = new Point(883, 245);
            radioNewton.Name = "radioNewton";
            radioNewton.Size = new Size(105, 32);
            radioNewton.TabIndex = 5;
            radioNewton.Text = "Ньютон";
            radioNewton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(767, 11);
            label5.Name = "label5";
            label5.Size = new Size(273, 56);
            label5.TabIndex = 1;
            label5.Text = "Для запису використовуйте \r\nмат. синтаксис C#!";
            label5.Click += label1_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(865, 294);
            button1.Name = "button1";
            button1.Size = new Size(187, 45);
            button1.TabIndex = 6;
            button1.Text = "Знайти корені";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(1017, 84);
            label6.Name = "label6";
            label6.Size = new Size(37, 28);
            label6.TabIndex = 1;
            label6.Text = "=0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(766, 86);
            label1.Name = "label1";
            label1.Size = new Size(57, 28);
            label1.TabIndex = 1;
            label1.Text = "F(x)=";
            // 
            // b_interval
            // 
            b_interval.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            b_interval.Location = new Point(901, 135);
            b_interval.Name = "b_interval";
            b_interval.Size = new Size(83, 34);
            b_interval.TabIndex = 8;
            b_interval.Text = "";
            // 
            // a_interval
            // 
            a_interval.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            a_interval.Location = new Point(797, 137);
            a_interval.Name = "a_interval";
            a_interval.Size = new Size(70, 34);
            a_interval.TabIndex = 9;
            a_interval.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 696);
            Controls.Add(a_interval);
            Controls.Add(b_interval);
            Controls.Add(button1);
            Controls.Add(radioNewton);
            Controls.Add(radioPF);
            Controls.Add(radioSI);
            Controls.Add(radioSecant);
            Controls.Add(radioChord);
            Controls.Add(answers);
            Controls.Add(epsilon);
            Controls.Add(function_text);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Розв'язання функціональних рівнянь із однією змінною F(x)=0";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private RichTextBox function_text;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox epsilon;
        private RichTextBox answers;
        private RadioButton radioChord;
        private RadioButton radioSecant;
        private RadioButton radioPF;
        private RadioButton radioSI;
        private RadioButton radioNewton;
        private Label label5;
        private Button button1;
        private Label label6;
        private Label label1;
        private RichTextBox b_interval;
        private RichTextBox a_interval;
    }
}
