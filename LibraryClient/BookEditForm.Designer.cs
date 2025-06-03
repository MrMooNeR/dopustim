namespace LibraryClient
{
    partial class BookEditForm
    {
                          private System.ComponentModel.IContainer components = null;

                                protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

                                private void InitializeComponent()
        {
            label1 = new Label();
            textBoxTitle = new TextBox();
            label2 = new Label();
            textBoxAuthor = new TextBox();
            buttonSave = new Button();
            SuspendLayout();
                                          label1.AutoSize = true;
            label1.Location = new Point(32, 24);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Название";
                                          textBoxTitle.Location = new Point(126, 21);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(125, 27);
            textBoxTitle.TabIndex = 1;
                                          label2.AutoSize = true;
            label2.Location = new Point(37, 89);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 2;
            label2.Text = "Автор";
                                          textBoxAuthor.Location = new Point(126, 82);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(125, 27);
            textBoxAuthor.TabIndex = 3;
                                          buttonSave.Location = new Point(39, 160);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
                                          AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSave);
            Controls.Add(textBoxAuthor);
            Controls.Add(label2);
            Controls.Add(textBoxTitle);
            Controls.Add(label1);
            Name = "BookEditForm";
            Text = "BookEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxTitle;
        private Label label2;
        private TextBox textBoxAuthor;
        private Button buttonSave;
    }
}