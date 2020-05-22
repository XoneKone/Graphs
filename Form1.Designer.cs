namespace Graphs
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
            this.output = new System.Windows.Forms.RichTextBox();
            this.Input_graph = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Output_edges_label = new System.Windows.Forms.Label();
            this.Output_vertices = new System.Windows.Forms.TextBox();
            this.Output_vertices_label = new System.Windows.Forms.Label();
            this.Output_Edges = new System.Windows.Forms.RichTextBox();
            this.origin_matrix_adj = new System.Windows.Forms.RichTextBox();
            this.origin_matrix_adj_label = new System.Windows.Forms.Label();
            this.output_label = new System.Windows.Forms.Label();
            this.Tasks = new System.Windows.Forms.ComboBox();
            this.Run1 = new System.Windows.Forms.Button();
            this.Tasks_label = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.output.Location = new System.Drawing.Point(595, 182);
            this.output.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(241, 191);
            this.output.TabIndex = 5;
            this.output.Text = "";
            // 
            // Input_graph
            // 
            this.Input_graph.Location = new System.Drawing.Point(145, 349);
            this.Input_graph.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Input_graph.Name = "Input_graph";
            this.Input_graph.Size = new System.Drawing.Size(238, 72);
            this.Input_graph.TabIndex = 2;
            this.Input_graph.Text = "Импортировать граф";
            this.Input_graph.UseVisualStyleBackColor = true;
            this.Input_graph.Click += new System.EventHandler(this.Input_graph_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Menu;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(576, 464);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // Output_edges_label
            // 
            this.Output_edges_label.AutoSize = true;
            this.Output_edges_label.Location = new System.Drawing.Point(80, 89);
            this.Output_edges_label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Output_edges_label.Name = "Output_edges_label";
            this.Output_edges_label.Size = new System.Drawing.Size(102, 19);
            this.Output_edges_label.TabIndex = 19;
            this.Output_edges_label.Text = "Список ребер";
            // 
            // Output_vertices
            // 
            this.Output_vertices.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Output_vertices.Location = new System.Drawing.Point(18, 35);
            this.Output_vertices.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Output_vertices.Name = "Output_vertices";
            this.Output_vertices.Size = new System.Drawing.Size(232, 29);
            this.Output_vertices.TabIndex = 18;
            // 
            // Output_vertices_label
            // 
            this.Output_vertices_label.AutoSize = true;
            this.Output_vertices_label.Location = new System.Drawing.Point(65, 9);
            this.Output_vertices_label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Output_vertices_label.Name = "Output_vertices_label";
            this.Output_vertices_label.Size = new System.Drawing.Size(117, 19);
            this.Output_vertices_label.TabIndex = 17;
            this.Output_vertices_label.Text = "Список вершин";
            // 
            // Output_Edges
            // 
            this.Output_Edges.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Output_Edges.Location = new System.Drawing.Point(18, 112);
            this.Output_Edges.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Output_Edges.Name = "Output_Edges";
            this.Output_Edges.Size = new System.Drawing.Size(232, 196);
            this.Output_Edges.TabIndex = 16;
            this.Output_Edges.Text = "";
            // 
            // origin_matrix_adj
            // 
            this.origin_matrix_adj.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.origin_matrix_adj.Location = new System.Drawing.Point(306, 38);
            this.origin_matrix_adj.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.origin_matrix_adj.Name = "origin_matrix_adj";
            this.origin_matrix_adj.Size = new System.Drawing.Size(247, 270);
            this.origin_matrix_adj.TabIndex = 20;
            this.origin_matrix_adj.Text = "";
            // 
            // origin_matrix_adj_label
            // 
            this.origin_matrix_adj_label.AutoSize = true;
            this.origin_matrix_adj_label.Location = new System.Drawing.Point(348, 9);
            this.origin_matrix_adj_label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.origin_matrix_adj_label.Name = "origin_matrix_adj_label";
            this.origin_matrix_adj_label.Size = new System.Drawing.Size(167, 19);
            this.origin_matrix_adj_label.TabIndex = 21;
            this.origin_matrix_adj_label.Text = "Матрица смежности";
            // 
            // output_label
            // 
            this.output_label.AutoSize = true;
            this.output_label.Location = new System.Drawing.Point(600, 159);
            this.output_label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.output_label.Name = "output_label";
            this.output_label.Size = new System.Drawing.Size(90, 19);
            this.output_label.TabIndex = 22;
            this.output_label.Text = "Результат";
            // 
            // Tasks
            // 
            this.Tasks.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tasks.FormattingEnabled = true;
            this.Tasks.Items.AddRange(new object[] {
            "Эйлеров путь",
            "Наибольшая клика (Брон-Кербош)",
            "Максимальный поток",
            "Наибольшее независимое множество",
            "Кратчайший путь (Флойд-Уоршелл)"});
            this.Tasks.Location = new System.Drawing.Point(604, 35);
            this.Tasks.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Tasks.Name = "Tasks";
            this.Tasks.Size = new System.Drawing.Size(382, 31);
            this.Tasks.TabIndex = 25;
            // 
            // Run1
            // 
            this.Run1.BackColor = System.Drawing.SystemColors.Menu;
            this.Run1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Run1.Location = new System.Drawing.Point(707, 78);
            this.Run1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Run1.Name = "Run1";
            this.Run1.Size = new System.Drawing.Size(159, 48);
            this.Run1.TabIndex = 24;
            this.Run1.Text = "Выполнить";
            this.Run1.UseVisualStyleBackColor = false;
            this.Run1.Click += new System.EventHandler(this.Run1_Click_1);
            // 
            // Tasks_label
            // 
            this.Tasks_label.AutoSize = true;
            this.Tasks_label.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tasks_label.Location = new System.Drawing.Point(687, 9);
            this.Tasks_label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Tasks_label.Name = "Tasks_label";
            this.Tasks_label.Size = new System.Drawing.Size(179, 19);
            this.Tasks_label.TabIndex = 23;
            this.Tasks_label.Text = "Выбрать индивидуалку";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(625, 393);
            this.save.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(338, 48);
            this.save.TabIndex = 26;
            this.save.Text = "Сохранить результаты";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 464);
            this.Controls.Add(this.save);
            this.Controls.Add(this.Tasks);
            this.Controls.Add(this.Run1);
            this.Controls.Add(this.Tasks_label);
            this.Controls.Add(this.output_label);
            this.Controls.Add(this.origin_matrix_adj_label);
            this.Controls.Add(this.origin_matrix_adj);
            this.Controls.Add(this.Output_edges_label);
            this.Controls.Add(this.Output_vertices);
            this.Controls.Add(this.Output_vertices_label);
            this.Controls.Add(this.Output_Edges);
            this.Controls.Add(this.output);
            this.Controls.Add(this.Input_graph);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button Input_graph;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label Output_edges_label;
        private System.Windows.Forms.TextBox Output_vertices;
        private System.Windows.Forms.Label Output_vertices_label;
        private System.Windows.Forms.RichTextBox Output_Edges;
        private System.Windows.Forms.RichTextBox origin_matrix_adj;
        private System.Windows.Forms.Label origin_matrix_adj_label;
        private System.Windows.Forms.Label output_label;
        private System.Windows.Forms.ComboBox Tasks;
        private System.Windows.Forms.Button Run1;
        private System.Windows.Forms.Label Tasks_label;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button save;
    }
}

