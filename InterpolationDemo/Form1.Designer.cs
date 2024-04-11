namespace InterpolationDemo
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
            graph = new ScottPlot.WinForms.FormsPlot();
            lagrange_textbox = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            spline_textbox = new RichTextBox();
            diff_plot = new ScottPlot.WinForms.FormsPlot();
            label = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            x1 = new RichTextBox();
            x2 = new RichTextBox();
            x3 = new RichTextBox();
            x4 = new RichTextBox();
            x5 = new RichTextBox();
            y1 = new RichTextBox();
            y2 = new RichTextBox();
            y3 = new RichTextBox();
            y4 = new RichTextBox();
            y5 = new RichTextBox();
            SpoxX0 = new RichTextBox();
            SpoxXn = new RichTextBox();
            h_textbox = new RichTextBox();
            SuspendLayout();
            // 
            // graph
            // 
            graph.DisplayScale = 1.25F;
            graph.Location = new Point(-2, 12);
            graph.Name = "graph";
            graph.Size = new Size(916, 652);
            graph.TabIndex = 0;
            // 
            // lagrange_textbox
            // 
            lagrange_textbox.Font = new Font("Segoe UI", 10F);
            lagrange_textbox.Location = new Point(12, 707);
            lagrange_textbox.Name = "lagrange_textbox";
            lagrange_textbox.Size = new Size(857, 120);
            lagrange_textbox.TabIndex = 2;
            lagrange_textbox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(366, 675);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 3;
            label1.Text = "Поліном Лагранжа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1438, 675);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 4;
            label2.Text = "Формули сплайнів";
            // 
            // spline_textbox
            // 
            spline_textbox.Font = new Font("Segoe UI", 10F);
            spline_textbox.Location = new Point(1009, 707);
            spline_textbox.Name = "spline_textbox";
            spline_textbox.Size = new Size(892, 120);
            spline_textbox.TabIndex = 5;
            spline_textbox.Text = "";
            // 
            // diff_plot
            // 
            diff_plot.DisplayScale = 1.25F;
            diff_plot.Location = new Point(985, 12);
            diff_plot.Name = "diff_plot";
            diff_plot.Size = new Size(949, 652);
            diff_plot.TabIndex = 7;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 853);
            label.Name = "label";
            label.Size = new Size(16, 20);
            label.TabIndex = 8;
            label.Text = "x";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 901);
            label3.Name = "label3";
            label3.Size = new Size(16, 20);
            label3.TabIndex = 8;
            label3.Text = "y";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(261, 850);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 8;
            label5.Text = "S'(x0)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(261, 889);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 8;
            label6.Text = "S'(xn)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(277, 925);
            label7.Name = "label7";
            label7.Size = new Size(17, 20);
            label7.TabIndex = 8;
            label7.Text = "h";
            // 
            // button1
            // 
            button1.Location = new Point(417, 885);
            button1.Name = "button1";
            button1.Size = new Size(228, 29);
            button1.TabIndex = 10;
            button1.Text = "Інтерполювати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // x1
            // 
            x1.Location = new Point(34, 850);
            x1.Name = "x1";
            x1.Size = new Size(36, 33);
            x1.TabIndex = 11;
            x1.Text = "0";
            // 
            // x2
            // 
            x2.Location = new Point(76, 850);
            x2.Name = "x2";
            x2.Size = new Size(36, 33);
            x2.TabIndex = 11;
            x2.Text = "4";
            // 
            // x3
            // 
            x3.Location = new Point(118, 850);
            x3.Name = "x3";
            x3.Size = new Size(36, 33);
            x3.TabIndex = 11;
            x3.Text = "7";
            // 
            // x4
            // 
            x4.Location = new Point(160, 850);
            x4.Name = "x4";
            x4.Size = new Size(36, 33);
            x4.TabIndex = 11;
            x4.Text = "10";
            // 
            // x5
            // 
            x5.Location = new Point(202, 850);
            x5.Name = "x5";
            x5.Size = new Size(36, 33);
            x5.TabIndex = 11;
            x5.Text = "12";
            // 
            // y1
            // 
            y1.Location = new Point(34, 893);
            y1.Name = "y1";
            y1.Size = new Size(36, 33);
            y1.TabIndex = 11;
            y1.Text = "1";
            // 
            // y2
            // 
            y2.Location = new Point(76, 893);
            y2.Name = "y2";
            y2.Size = new Size(36, 33);
            y2.TabIndex = 11;
            y2.Text = "3";
            // 
            // y3
            // 
            y3.Location = new Point(118, 893);
            y3.Name = "y3";
            y3.Size = new Size(36, 33);
            y3.TabIndex = 11;
            y3.Text = "7";
            // 
            // y4
            // 
            y4.Location = new Point(160, 893);
            y4.Name = "y4";
            y4.Size = new Size(36, 33);
            y4.TabIndex = 11;
            y4.Text = "5";
            // 
            // y5
            // 
            y5.Location = new Point(202, 893);
            y5.Name = "y5";
            y5.Size = new Size(36, 33);
            y5.TabIndex = 11;
            y5.Text = "6";
            // 
            // SpoxX0
            // 
            SpoxX0.Location = new Point(312, 847);
            SpoxX0.Name = "SpoxX0";
            SpoxX0.Size = new Size(36, 33);
            SpoxX0.TabIndex = 11;
            SpoxX0.Text = "0,1";
            // 
            // SpoxXn
            // 
            SpoxXn.Location = new Point(312, 885);
            SpoxXn.Name = "SpoxXn";
            SpoxXn.Size = new Size(36, 33);
            SpoxXn.TabIndex = 11;
            SpoxXn.Text = "-0,5";
            // 
            // h_textbox
            // 
            h_textbox.Location = new Point(312, 922);
            h_textbox.Name = "h_textbox";
            h_textbox.Size = new Size(36, 33);
            h_textbox.TabIndex = 11;
            h_textbox.Text = "0,2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1913, 982);
            Controls.Add(y5);
            Controls.Add(h_textbox);
            Controls.Add(SpoxXn);
            Controls.Add(SpoxX0);
            Controls.Add(x5);
            Controls.Add(y4);
            Controls.Add(x4);
            Controls.Add(y3);
            Controls.Add(x3);
            Controls.Add(y2);
            Controls.Add(x2);
            Controls.Add(y1);
            Controls.Add(x1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label);
            Controls.Add(diff_plot);
            Controls.Add(spline_textbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lagrange_textbox);
            Controls.Add(graph);
            Name = "Form1";
            Text = "Апроксимація функцій, заданих таблично (n=5), поліномом Лагранжа та сплайн-інтерполяцією";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot graph;
        private RichTextBox lagrange_textbox;
        private Label label1;
        private Label label2;
        private RichTextBox spline_textbox;
        private ScottPlot.WinForms.FormsPlot diff_plot;
        private Label label;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private RichTextBox x1;
        private RichTextBox x2;
        private RichTextBox x3;
        private RichTextBox x4;
        private RichTextBox x5;
        private RichTextBox y1;
        private RichTextBox y2;
        private RichTextBox y3;
        private RichTextBox y4;
        private RichTextBox y5;
        private RichTextBox SpoxX0;
        private RichTextBox SpoxXn;
        private RichTextBox h_textbox;
    }
}
