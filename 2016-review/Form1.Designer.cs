namespace _2016_review
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ReflectionBtn = new System.Windows.Forms.Button();
            this.regexBtn = new System.Windows.Forms.Button();
            this.baseTestButton = new System.Windows.Forms.Button();
            this.pictureTestButton = new System.Windows.Forms.Button();
            this.classTestButton = new System.Windows.Forms.Button();
            this.interfaceTestButton = new System.Windows.Forms.Button();
            this.eventTestButton = new System.Windows.Forms.Button();
            this.advanceTestButton = new System.Windows.Forms.Button();
            this.linqTestButton = new System.Windows.Forms.Button();
            this.objectLifetimeTestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentProgramMem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeapMem = new System.Windows.Forms.Label();
            this.processTestButton = new System.Windows.Forms.Button();
            this.assemblyTestButton = new System.Windows.Forms.Button();
            this.multiThreadTestButton = new System.Windows.Forms.Button();
            this.backgroundWorkerOutput = new System.ComponentModel.BackgroundWorker();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.resultLabel2 = new System.Windows.Forms.Label();
            this.multiThreadTest2Button = new System.Windows.Forms.Button();
            this.multiThreadTest3Button = new System.Windows.Forms.Button();
            this.multiThreadTest4Button = new System.Windows.Forms.Button();
            this.multiThreadTaskButton = new System.Windows.Forms.Button();
            this.cancelTestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 54);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1133, 414);
            this.textBox1.TabIndex = 0;
            // 
            // ReflectionBtn
            // 
            this.ReflectionBtn.Location = new System.Drawing.Point(35, 493);
            this.ReflectionBtn.Name = "ReflectionBtn";
            this.ReflectionBtn.Size = new System.Drawing.Size(120, 44);
            this.ReflectionBtn.TabIndex = 1;
            this.ReflectionBtn.Text = "反射测试";
            this.ReflectionBtn.UseVisualStyleBackColor = true;
            this.ReflectionBtn.Click += new System.EventHandler(this.ReflectionBtn_Click);
            // 
            // regexBtn
            // 
            this.regexBtn.Location = new System.Drawing.Point(173, 493);
            this.regexBtn.Name = "regexBtn";
            this.regexBtn.Size = new System.Drawing.Size(120, 44);
            this.regexBtn.TabIndex = 2;
            this.regexBtn.Text = "正则测试";
            this.regexBtn.UseVisualStyleBackColor = true;
            this.regexBtn.Click += new System.EventHandler(this.RegexBtn_Click);
            // 
            // baseTestButton
            // 
            this.baseTestButton.Location = new System.Drawing.Point(310, 493);
            this.baseTestButton.Name = "baseTestButton";
            this.baseTestButton.Size = new System.Drawing.Size(120, 44);
            this.baseTestButton.TabIndex = 3;
            this.baseTestButton.Text = "基础测试";
            this.baseTestButton.UseVisualStyleBackColor = true;
            this.baseTestButton.Click += new System.EventHandler(this.BaseTestButton_Click);
            // 
            // pictureTestButton
            // 
            this.pictureTestButton.Location = new System.Drawing.Point(452, 493);
            this.pictureTestButton.Name = "pictureTestButton";
            this.pictureTestButton.Size = new System.Drawing.Size(120, 44);
            this.pictureTestButton.TabIndex = 4;
            this.pictureTestButton.Text = "图片测试";
            this.pictureTestButton.UseVisualStyleBackColor = true;
            this.pictureTestButton.Click += new System.EventHandler(this.PictureTestButton_Click);
            // 
            // classTestButton
            // 
            this.classTestButton.Location = new System.Drawing.Point(593, 493);
            this.classTestButton.Name = "classTestButton";
            this.classTestButton.Size = new System.Drawing.Size(120, 44);
            this.classTestButton.TabIndex = 5;
            this.classTestButton.Text = "类测试";
            this.classTestButton.UseVisualStyleBackColor = true;
            this.classTestButton.Click += new System.EventHandler(this.ClassTestButton_Click);
            // 
            // interfaceTestButton
            // 
            this.interfaceTestButton.Location = new System.Drawing.Point(730, 493);
            this.interfaceTestButton.Name = "interfaceTestButton";
            this.interfaceTestButton.Size = new System.Drawing.Size(120, 44);
            this.interfaceTestButton.TabIndex = 6;
            this.interfaceTestButton.Text = "接口测试";
            this.interfaceTestButton.UseVisualStyleBackColor = true;
            this.interfaceTestButton.Click += new System.EventHandler(this.InterfaceTestButton_Click);
            // 
            // eventTestButton
            // 
            this.eventTestButton.Location = new System.Drawing.Point(866, 493);
            this.eventTestButton.Name = "eventTestButton";
            this.eventTestButton.Size = new System.Drawing.Size(120, 44);
            this.eventTestButton.TabIndex = 7;
            this.eventTestButton.Text = "事件委托";
            this.eventTestButton.UseVisualStyleBackColor = true;
            this.eventTestButton.Click += new System.EventHandler(this.EventTestButton_Click);
            // 
            // advanceTestButton
            // 
            this.advanceTestButton.Location = new System.Drawing.Point(1011, 493);
            this.advanceTestButton.Name = "advanceTestButton";
            this.advanceTestButton.Size = new System.Drawing.Size(157, 44);
            this.advanceTestButton.TabIndex = 8;
            this.advanceTestButton.Text = "高级语言特性";
            this.advanceTestButton.UseVisualStyleBackColor = true;
            this.advanceTestButton.Click += new System.EventHandler(this.AdvanceTestButton_Click);
            // 
            // linqTestButton
            // 
            this.linqTestButton.Location = new System.Drawing.Point(35, 566);
            this.linqTestButton.Name = "linqTestButton";
            this.linqTestButton.Size = new System.Drawing.Size(120, 44);
            this.linqTestButton.TabIndex = 9;
            this.linqTestButton.Text = "LINQ测试";
            this.linqTestButton.UseVisualStyleBackColor = true;
            this.linqTestButton.Click += new System.EventHandler(this.LinqTestButton_Click);
            // 
            // objectLifetimeTestButton
            // 
            this.objectLifetimeTestButton.Location = new System.Drawing.Point(173, 566);
            this.objectLifetimeTestButton.Name = "objectLifetimeTestButton";
            this.objectLifetimeTestButton.Size = new System.Drawing.Size(155, 44);
            this.objectLifetimeTestButton.TabIndex = 10;
            this.objectLifetimeTestButton.Text = "对象生命周期";
            this.objectLifetimeTestButton.UseVisualStyleBackColor = true;
            this.objectLifetimeTestButton.Click += new System.EventHandler(this.ObjectLifetimeTestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 713);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "当前程序使用内存:";
            // 
            // labelCurrentProgramMem
            // 
            this.labelCurrentProgramMem.AutoSize = true;
            this.labelCurrentProgramMem.Location = new System.Drawing.Point(35, 746);
            this.labelCurrentProgramMem.Name = "labelCurrentProgramMem";
            this.labelCurrentProgramMem.Size = new System.Drawing.Size(17, 18);
            this.labelCurrentProgramMem.TabIndex = 12;
            this.labelCurrentProgramMem.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 712);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "堆上预估字节数:";
            // 
            // labelHeapMem
            // 
            this.labelHeapMem.AutoSize = true;
            this.labelHeapMem.Location = new System.Drawing.Point(319, 746);
            this.labelHeapMem.Name = "labelHeapMem";
            this.labelHeapMem.Size = new System.Drawing.Size(17, 18);
            this.labelHeapMem.TabIndex = 14;
            this.labelHeapMem.Text = "0";
            // 
            // processTestButton
            // 
            this.processTestButton.Location = new System.Drawing.Point(489, 566);
            this.processTestButton.Name = "processTestButton";
            this.processTestButton.Size = new System.Drawing.Size(120, 44);
            this.processTestButton.TabIndex = 15;
            this.processTestButton.Text = "进程测试";
            this.processTestButton.UseVisualStyleBackColor = true;
            this.processTestButton.Click += new System.EventHandler(this.ProcessTestButton_Click);
            // 
            // assemblyTestButton
            // 
            this.assemblyTestButton.Location = new System.Drawing.Point(342, 566);
            this.assemblyTestButton.Name = "assemblyTestButton";
            this.assemblyTestButton.Size = new System.Drawing.Size(120, 44);
            this.assemblyTestButton.TabIndex = 16;
            this.assemblyTestButton.Text = "程序集测试";
            this.assemblyTestButton.UseVisualStyleBackColor = true;
            this.assemblyTestButton.Click += new System.EventHandler(this.assemblyTestButton_Click);
            // 
            // multiThreadTestButton
            // 
            this.multiThreadTestButton.Location = new System.Drawing.Point(635, 566);
            this.multiThreadTestButton.Name = "multiThreadTestButton";
            this.multiThreadTestButton.Size = new System.Drawing.Size(120, 44);
            this.multiThreadTestButton.TabIndex = 17;
            this.multiThreadTestButton.Text = "多线程测试";
            this.multiThreadTestButton.UseVisualStyleBackColor = true;
            this.multiThreadTestButton.Click += new System.EventHandler(this.MultiThreadTestButton_Click);
            // 
            // backgroundWorkerOutput
            // 
            this.backgroundWorkerOutput.WorkerReportsProgress = true;
            this.backgroundWorkerOutput.WorkerSupportsCancellation = true;
            this.backgroundWorkerOutput.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerOutput_DoWork);
            this.backgroundWorkerOutput.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerOutput_ProgressChanged);
            this.backgroundWorkerOutput.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerOutput_RunWorkerCompleted);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(129, 13);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(26, 18);
            this.resultLabel.TabIndex = 18;
            this.resultLabel.Text = " 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "当前进度:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "当前进度:";
            // 
            // resultLabel2
            // 
            this.resultLabel2.AutoSize = true;
            this.resultLabel2.Location = new System.Drawing.Point(275, 13);
            this.resultLabel2.Name = "resultLabel2";
            this.resultLabel2.Size = new System.Drawing.Size(26, 18);
            this.resultLabel2.TabIndex = 20;
            this.resultLabel2.Text = " 0";
            // 
            // multiThreadTest2Button
            // 
            this.multiThreadTest2Button.Location = new System.Drawing.Point(773, 566);
            this.multiThreadTest2Button.Name = "multiThreadTest2Button";
            this.multiThreadTest2Button.Size = new System.Drawing.Size(120, 44);
            this.multiThreadTest2Button.TabIndex = 22;
            this.multiThreadTest2Button.Text = "多线程测试2";
            this.multiThreadTest2Button.UseVisualStyleBackColor = true;
            this.multiThreadTest2Button.Click += new System.EventHandler(this.multiThreadTest2Button_Click);
            // 
            // multiThreadTest3Button
            // 
            this.multiThreadTest3Button.Location = new System.Drawing.Point(910, 566);
            this.multiThreadTest3Button.Name = "multiThreadTest3Button";
            this.multiThreadTest3Button.Size = new System.Drawing.Size(120, 44);
            this.multiThreadTest3Button.TabIndex = 23;
            this.multiThreadTest3Button.Text = "多线程测试3";
            this.multiThreadTest3Button.UseVisualStyleBackColor = true;
            this.multiThreadTest3Button.Click += new System.EventHandler(this.multiThreadTest3Button_Click);
            // 
            // multiThreadTest4Button
            // 
            this.multiThreadTest4Button.Location = new System.Drawing.Point(38, 633);
            this.multiThreadTest4Button.Name = "multiThreadTest4Button";
            this.multiThreadTest4Button.Size = new System.Drawing.Size(158, 44);
            this.multiThreadTest4Button.TabIndex = 24;
            this.multiThreadTest4Button.Text = "async和await";
            this.multiThreadTest4Button.UseVisualStyleBackColor = true;
            this.multiThreadTest4Button.Click += new System.EventHandler(this.multiThreadTest4Button_Click);
            // 
            // multiThreadTaskButton
            // 
            this.multiThreadTaskButton.Location = new System.Drawing.Point(1048, 566);
            this.multiThreadTaskButton.Name = "multiThreadTaskButton";
            this.multiThreadTaskButton.Size = new System.Drawing.Size(120, 44);
            this.multiThreadTaskButton.TabIndex = 25;
            this.multiThreadTaskButton.Text = "Task测试";
            this.multiThreadTaskButton.UseVisualStyleBackColor = true;
            this.multiThreadTaskButton.Click += new System.EventHandler(this.multiThreadTaskButton_Click);
            // 
            // cancelTestButton
            // 
            this.cancelTestButton.Location = new System.Drawing.Point(1048, 633);
            this.cancelTestButton.Name = "cancelTestButton";
            this.cancelTestButton.Size = new System.Drawing.Size(120, 44);
            this.cancelTestButton.TabIndex = 26;
            this.cancelTestButton.Text = "取消测试";
            this.cancelTestButton.UseVisualStyleBackColor = true;
            this.cancelTestButton.Click += new System.EventHandler(this.cancelTestButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 785);
            this.Controls.Add(this.cancelTestButton);
            this.Controls.Add(this.multiThreadTaskButton);
            this.Controls.Add(this.multiThreadTest4Button);
            this.Controls.Add(this.multiThreadTest3Button);
            this.Controls.Add(this.multiThreadTest2Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resultLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.multiThreadTestButton);
            this.Controls.Add(this.assemblyTestButton);
            this.Controls.Add(this.processTestButton);
            this.Controls.Add(this.labelHeapMem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrentProgramMem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.objectLifetimeTestButton);
            this.Controls.Add(this.linqTestButton);
            this.Controls.Add(this.advanceTestButton);
            this.Controls.Add(this.eventTestButton);
            this.Controls.Add(this.interfaceTestButton);
            this.Controls.Add(this.classTestButton);
            this.Controls.Add(this.pictureTestButton);
            this.Controls.Add(this.baseTestButton);
            this.Controls.Add(this.regexBtn);
            this.Controls.Add(this.ReflectionBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "2016复习";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReflectionBtn;
        private System.Windows.Forms.Button regexBtn;
        private System.Windows.Forms.Button baseTestButton;
        private System.Windows.Forms.Button pictureTestButton;
        private System.Windows.Forms.Button classTestButton;
        private System.Windows.Forms.Button interfaceTestButton;
        private System.Windows.Forms.Button eventTestButton;
        private System.Windows.Forms.Button advanceTestButton;
        private System.Windows.Forms.Button linqTestButton;
        private System.Windows.Forms.Button objectLifetimeTestButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentProgramMem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHeapMem;
        private System.Windows.Forms.Button processTestButton;
        private System.Windows.Forms.Button assemblyTestButton;
        private System.Windows.Forms.Button multiThreadTestButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerOutput;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label resultLabel2;
        private System.Windows.Forms.Button multiThreadTest2Button;
        private System.Windows.Forms.Button multiThreadTest3Button;
        private System.Windows.Forms.Button multiThreadTest4Button;
        private System.Windows.Forms.Button multiThreadTaskButton;
        private System.Windows.Forms.Button cancelTestButton;
    }
}

