namespace WinFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            first_equation = new RichTextBox();
            second_equation = new RichTextBox();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            label6 = new Label();
            iter_x = new RichTextBox();
            iter_y = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ZeidelRadio = new RadioButton();
            NewtonRadio = new RadioButton();
            IterationsRation = new RadioButton();
            label5 = new Label();
            variants = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            x0_text = new RichTextBox();
            y0_text = new RichTextBox();
            label4 = new Label();
            accuracy_text = new RichTextBox();
            answers_textbox = new RichTextBox();
            solvesystem_button = new Button();
            answers_check = new RichTextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(1, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(761, 744);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(787, 99);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 77);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // first_equation
            // 
            first_equation.Font = new Font("Segoe UI", 12F);
            first_equation.Location = new Point(824, 99);
            first_equation.Name = "first_equation";
            first_equation.Size = new Size(265, 37);
            first_equation.TabIndex = 3;
            first_equation.Text = "";
            // 
            // second_equation
            // 
            second_equation.Font = new Font("Segoe UI", 12F);
            second_equation.Location = new Point(824, 142);
            second_equation.Name = "second_equation";
            second_equation.Size = new Size(265, 34);
            second_equation.TabIndex = 3;
            second_equation.Text = "";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(1130, 99);
            button1.Name = "button1";
            button1.Size = new Size(188, 39);
            button1.TabIndex = 4;
            button1.Text = "Побудувати графік";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DrawGraph;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(787, 214);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(44, 88);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(769, 9);
            label6.Name = "label6";
            label6.Size = new Size(537, 112);
            label6.TabIndex = 1;
            label6.Text = "Введіть рівняння у вигляді f(x,y)=0. \r\nДля запису використовуйте математичний синтаксис C#!\r\nПриклад: Cos(x)-Pow(y,3)-9\r\n\r\n";
            label6.Click += label1_Click;
            // 
            // iter_x
            // 
            iter_x.Font = new Font("Segoe UI", 12F);
            iter_x.Location = new Point(854, 211);
            iter_x.Name = "iter_x";
            iter_x.Size = new Size(235, 40);
            iter_x.TabIndex = 3;
            iter_x.Text = "";
            // 
            // iter_y
            // 
            iter_y.Font = new Font("Segoe UI", 12F);
            iter_y.Location = new Point(854, 257);
            iter_y.Name = "iter_y";
            iter_y.Size = new Size(235, 38);
            iter_y.TabIndex = 3;
            iter_y.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(818, 214);
            label7.Name = "label7";
            label7.Size = new Size(35, 28);
            label7.TabIndex = 5;
            label7.Text = "x=";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(818, 257);
            label8.Name = "label8";
            label8.Size = new Size(36, 28);
            label8.TabIndex = 5;
            label8.Text = "y=";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(768, 179);
            label9.Name = "label9";
            label9.Size = new Size(599, 28);
            label9.TabIndex = 6;
            label9.Text = "Представте систему в ітераційному вигляді (для ітерац. методів)";
            // 
            // ZeidelRadio
            // 
            ZeidelRadio.AutoSize = true;
            ZeidelRadio.Font = new Font("Segoe UI", 12F);
            ZeidelRadio.Location = new Point(1115, 212);
            ZeidelRadio.Name = "ZeidelRadio";
            ZeidelRadio.Size = new Size(108, 32);
            ZeidelRadio.TabIndex = 7;
            ZeidelRadio.TabStop = true;
            ZeidelRadio.Text = "Зейдель";
            ZeidelRadio.UseVisualStyleBackColor = true;
            // 
            // NewtonRadio
            // 
            NewtonRadio.AutoSize = true;
            NewtonRadio.Font = new Font("Segoe UI", 12F);
            NewtonRadio.Location = new Point(1229, 214);
            NewtonRadio.Name = "NewtonRadio";
            NewtonRadio.Size = new Size(105, 32);
            NewtonRadio.TabIndex = 7;
            NewtonRadio.TabStop = true;
            NewtonRadio.Text = "Ньютон";
            NewtonRadio.UseVisualStyleBackColor = true;
            // 
            // IterationsRation
            // 
            IterationsRation.AutoSize = true;
            IterationsRation.Font = new Font("Segoe UI", 12F);
            IterationsRation.Location = new Point(1115, 250);
            IterationsRation.Name = "IterationsRation";
            IterationsRation.Size = new Size(100, 32);
            IterationsRation.TabIndex = 7;
            IterationsRation.TabStop = true;
            IterationsRation.Text = "Ітерації";
            IterationsRation.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(1167, 145);
            label5.Name = "label5";
            label5.Size = new Size(82, 25);
            label5.TabIndex = 9;
            label5.Text = "Варіанти";
            // 
            // variants
            // 
            variants.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            variants.FormattingEnabled = true;
            variants.Location = new Point(1255, 142);
            variants.Name = "variants";
            variants.Size = new Size(51, 33);
            variants.TabIndex = 10;
            variants.SelectedIndexChanged += variants_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(768, 305);
            label1.Name = "label1";
            label1.Size = new Size(300, 28);
            label1.TabIndex = 11;
            label1.Text = "Введіть початкове наближення";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(1074, 305);
            label2.Name = "label2";
            label2.Size = new Size(46, 28);
            label2.TabIndex = 12;
            label2.Text = "x0=";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(1229, 305);
            label3.Name = "label3";
            label3.Size = new Size(47, 28);
            label3.TabIndex = 13;
            label3.Text = "y0=";
            // 
            // x0_text
            // 
            x0_text.Font = new Font("Segoe UI", 10.8F);
            x0_text.Location = new Point(1116, 301);
            x0_text.Name = "x0_text";
            x0_text.Size = new Size(107, 38);
            x0_text.TabIndex = 14;
            x0_text.Text = "";
            // 
            // y0_text
            // 
            y0_text.Font = new Font("Segoe UI", 10.8F);
            y0_text.Location = new Point(1270, 301);
            y0_text.Name = "y0_text";
            y0_text.Size = new Size(90, 38);
            y0_text.TabIndex = 14;
            y0_text.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(1226, 249);
            label4.Name = "label4";
            label4.Size = new Size(35, 28);
            label4.TabIndex = 15;
            label4.Text = "ε=";
            // 
            // accuracy_text
            // 
            accuracy_text.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            accuracy_text.Location = new Point(1255, 248);
            accuracy_text.Name = "accuracy_text";
            accuracy_text.Size = new Size(99, 32);
            accuracy_text.TabIndex = 16;
            accuracy_text.Text = "0.001";
            // 
            // answers_textbox
            // 
            answers_textbox.Font = new Font("Segoe UI", 14F);
            answers_textbox.Location = new Point(798, 393);
            answers_textbox.Name = "answers_textbox";
            answers_textbox.Size = new Size(556, 225);
            answers_textbox.TabIndex = 17;
            answers_textbox.Text = "";
            // 
            // solvesystem_button
            // 
            solvesystem_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            solvesystem_button.Location = new Point(988, 343);
            solvesystem_button.Name = "solvesystem_button";
            solvesystem_button.Size = new Size(172, 44);
            solvesystem_button.TabIndex = 18;
            solvesystem_button.Text = "Розв'язати СНАР";
            solvesystem_button.UseVisualStyleBackColor = true;
            solvesystem_button.Click += solvesystem_button_Click;
            // 
            // answers_check
            // 
            answers_check.Font = new Font("Segoe UI", 10.8F);
            answers_check.Location = new Point(1032, 664);
            answers_check.Name = "answers_check";
            answers_check.Size = new Size(274, 62);
            answers_check.TabIndex = 19;
            answers_check.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(977, 621);
            label10.Name = "label10";
            label10.Size = new Size(223, 28);
            label10.TabIndex = 20;
            label10.Text = "Перевірка розв'язання";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(863, 664);
            label11.Name = "label11";
            label11.Size = new Size(163, 28);
            label11.TabIndex = 20;
            label11.Text = "Перше рівняння";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(863, 692);
            label12.Name = "label12";
            label12.Size = new Size(155, 28);
            label12.TabIndex = 20;
            label12.Text = "Друге рівняння";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1375, 738);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(answers_check);
            Controls.Add(solvesystem_button);
            Controls.Add(answers_textbox);
            Controls.Add(accuracy_text);
            Controls.Add(label4);
            Controls.Add(y0_text);
            Controls.Add(x0_text);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(variants);
            Controls.Add(label5);
            Controls.Add(IterationsRation);
            Controls.Add(NewtonRadio);
            Controls.Add(ZeidelRadio);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(iter_y);
            Controls.Add(second_equation);
            Controls.Add(iter_x);
            Controls.Add(pictureBox3);
            Controls.Add(first_equation);
            Controls.Add(pictureBox2);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private RichTextBox first_equation;
        private RichTextBox second_equation;
        private Button button1;
        private PictureBox pictureBox3;
        private Label label6;
        private RichTextBox iter_x;
        private RichTextBox iter_y;
        private Label label7;
        private Label label8;
        private Label label9;
        private RadioButton ZeidelRadio;
        private RadioButton NewtonRadio;
        private RadioButton IterationsRation;
        private Label label5;
        private ComboBox variants;
        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox x0_text;
        private RichTextBox y0_text;
        private Label label4;
        private RichTextBox accuracy_text;
        private RichTextBox answers_textbox;
        private Button solvesystem_button;
        private RichTextBox answers_check;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}
