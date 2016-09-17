using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Net;
using System.Net.Http;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace _2016_review
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void ReflectionBtn_Click(object sender, EventArgs e)
        {
            
            foreach ( ImageMagick.CompositeOperator watermarkType   in (ImageMagick.CompositeOperator[])Enum.GetValues(typeof(ImageMagick.CompositeOperator)))
            {
                textBox1.AppendText(watermarkType.ToString() + "\n");
            }
            
            /*
            ImageMagick.CompositeOperator testOperator = new ImageMagick.CompositeOperator();
            Array enumData = Enum.GetValues(testOperator.GetType());
            foreach (var item in enumData)
            {
                textBox1.AppendText(item.GetType() + "\n");
            }
            */
        }

        private void RegexBtn_Click(object sender, EventArgs e)
        {
            //平衡组 我们现在要匹配的最外层的括号的内容
            string strTag = "xx <aa <bbb> <bbb> aa> yy>"; //要匹配的目标是 <aa <bbb> <bbb> aa>  ，注意括号数不等
            Regex reg = new Regex("<.+>");
            textBox1.AppendText("match pattern: <.+> \n");
            textBox1.AppendText(reg.Match(strTag).ToString()+"\n"); //输出 <aa <bbb> <bbb> aa> yy>    看到与希望匹配的目标不一致，主要是因为 < 与 > 的数量不相等

            //string matchPattern2 = "<[^<>]*(((?'Open'<)[^<>]*)+((?'-Open'>)[^<>]*)+))*(?(Open)(?!))";
            string matchPattern2 = "<[^<>]*(((?'Open'<)[^<>]*)+((?'-Open'>)[^<>]+))*(?(Open)(?!))>";
            Regex reg2 = new Regex(matchPattern2);
            textBox1.AppendText(reg2.Match(strTag).ToString() + "\n");
        }

        private long GetUnixtimeStamp(DateTime dt)
        {
            TimeSpan ts = new TimeSpan();
            ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0);
            return (long)ts.TotalSeconds;
        }
        private void  SwithOnEnumTest(string favDayInput)
        {
            DayOfWeek favDay;
            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), favDayInput);
                switch (favDay)
                {
                    case DayOfWeek.Sunday:
                        textBox1.AppendText(string.Format("Yes! {0} not good as saturday, but already happy! \n", favDay.ToString()));
                        break;
                    case DayOfWeek.Monday:
                        textBox1.AppendText(string.Format("lol ! {0}  not happy! It's a busy day! \n", favDay.ToString()));
                        break;
                    case DayOfWeek.Tuesday:
                        textBox1.AppendText(string.Format("~~~! {0} another busy day! \n", favDay.ToString()));
                        break;
                    case DayOfWeek.Wednesday:
                        textBox1.AppendText(string.Format("good! {0} have a little rest now! \n", favDay.ToString()));
                        break;
                    case DayOfWeek.Thursday:
                        textBox1.AppendText(string.Format("yeah! {0} almost weekend! \n", favDay.ToString()));
                        break;
                    case DayOfWeek.Friday:
                        textBox1.AppendText(string.Format("Exciting ! {0} finally there comes weekend! \n", favDay.ToString()));
                        break;
                    case DayOfWeek.Saturday:
                        textBox1.AppendText(string.Format("Great ! {0} is the happiest day ! \n", favDay.ToString()));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                textBox1.AppendText(string.Format("Input error: {0} \n", e.Message));
            }
        }

        private void BaseTestButton_Click(object sender, EventArgs e)
        {
            //时间类的测试
            DateTime testDate = DateTime.Parse("2016/8/12 22:35:13");
            //DateTime testDate = new DateTime(2016, 8, 12, 22, 35, 13);
            long testUnixtime = GetUnixtimeStamp(testDate);
            textBox1.AppendText(string.Format("time : 2016 / 8 / 12 22:35:13 unixtime: {0}\n", testUnixtime));

            //switch方法的测试
            SwithOnEnumTest("Friday");
            //集合和范型
            ArrayList strArr = new ArrayList() { "One", "Two", "Three" };
            strArr.AddRange(new string[] { "Four", "Five" });
            foreach (string item in strArr)
            {
                textBox1.AppendText(string.Format("value of arraylist: {0}\n", item));
            }
            //System.Collections.ObjectModel 测试;
            ObservableCollection<Car> myAutos = new ObservableCollection<Car>
            {
                new Car("Buick",80),
                new Car("Qirui",90),
                new Car("Rongwei",80),
            };
            myAutos.CollectionChanged += MyAutos_CollectionChanged;
            myAutos.Add(new Car("Geely", 70));
            myAutos.RemoveAt(1);
        }

        private void MyAutos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action==System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                textBox1.AppendText("下面是新增加的节点:\n");
                foreach (Car oneCar in e.NewItems)
                {
                    textBox1.AppendText(string.Format("增加的节点名称: {0} 最大速度: {1} \n", oneCar.CarName, oneCar._maxSpeed));
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                textBox1.AppendText("下面是删除的节点:\n");
                foreach (Car oneCar in e.OldItems)
                {
                    textBox1.AppendText(string.Format("删除的节点名称: {0} 最大速度: {1} \n", oneCar.CarName, oneCar._maxSpeed));
                }
            }
        }
        #region 图片测试
        private string MakeThumb(string srcPicPath,string dstPicPath,int dstWidth=200 ,int dstHeight=200, string mode="Cut")
        {
            Image srcImg = Image.FromFile(srcPicPath);
            int originWidth = srcImg.Width;
            int originHeigth = srcImg.Height;
            int drawWidth = originWidth;
            int drawHeight = originHeigth;
            //double currentRatio = originHeigth / originWidth;
            //double dstRatio = dstheight / dstWidth;
            decimal currentRatio = (decimal)originHeigth / originWidth;
            decimal dstRatio = (decimal)dstHeight / dstWidth;
            int x = 0;
            int y = 0;
            switch (mode)
            {
                case "HW":
                    break;
                case "W":
                    drawHeight = (int)Math.Round(drawWidth * dstRatio);
                    break;
                case "H":
                    drawWidth = (int)Math.Round(drawHeight /dstRatio);
                    break;
                case "Cut":
                    bool preserveWidth = false;
                    if (currentRatio > dstRatio)
                    {
                        preserveWidth = true;
                    }
                    if (preserveWidth)
                    {
                        //drawHeight = drawWidth * originHeigth / originWidth;
                        drawHeight = (int)Math.Round(drawWidth*dstRatio);
                    }
                    else
                    {
                        //drawWidth = drawHeight * originWidth / originHeigth;
                        drawWidth = (int)Math.Round(drawHeight / dstRatio);
                        x = (originWidth - drawWidth) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            Image thumbImg = new Bitmap(dstWidth, dstHeight);
            //新建一个画板
            Graphics drawImg = Graphics.FromImage(thumbImg);
            //清空画布并以透明背景色填充
            drawImg.Clear(Color.Transparent);
            //设置高质量插值法
            drawImg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            drawImg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //设置目标绘画大小
            Rectangle dstRectangle = new Rectangle(0, 0, dstWidth, dstHeight);
            //设置从原图中获取的绘画区域
            Rectangle drawRectangle = new Rectangle(x, y, drawWidth, drawHeight);
            //在指定位置并且按指定大小绘制原图片的指定部分
            drawImg.DrawImage(srcImg, dstRectangle, drawRectangle, GraphicsUnit.Pixel);
            //以jpeg格式保存新的绘画图片
            try
            {
                thumbImg.Save(dstPicPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return " Create " + dstPicPath + " successfully!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        enum thumbMode
        {
            HW,  //按指定的高度和宽度生成缩略图,可能会产生变形
            H,  //按指定的高度生成缩略图, 宽度按比例生成
            W, //按指定的宽度,高度按比例生成
            Cut  // 按原图的比例进行等比例缩放
        }
        private string MakeThumbNew(string srcPicPath,string dstPicPath,int thumbWidth=200,int thumbHeight=200,thumbMode mode=thumbMode.Cut,int quality=100)
        {
            ImageMagick.MagickImage srcImg = new ImageMagick.MagickImage(srcPicPath);
            int originWidth = srcImg.Width;
            int originHeight = srcImg.Height;
            int cropWidth = thumbWidth;
            int cropHeight = thumbHeight;
            decimal currentRatio = (decimal)originHeight / originWidth;
            decimal dstRatio = (decimal)thumbHeight / thumbWidth;
            ImageMagick.Gravity cropPosition = ImageMagick.Gravity.Center;
            if (originWidth != thumbWidth || originHeight != thumbHeight)
            {
                switch (mode)
                {
                    case thumbMode.HW:
                        break;
                    case thumbMode.H:
                        thumbWidth = (int)Math.Round(thumbHeight / currentRatio);
                        break;
                    case thumbMode.W:
                        thumbHeight = (int)Math.Round(thumbWidth * currentRatio);
                        cropPosition = ImageMagick.Gravity.North;
                        break;
                    case thumbMode.Cut:
                        bool preserveWidth = (currentRatio > dstRatio) ? true : false;
                        if (preserveWidth)
                        {
                            thumbHeight = (int)Math.Round(thumbWidth * currentRatio);
                            cropPosition = ImageMagick.Gravity.North;
                        }
                        else
                        {
                            thumbWidth = (int)Math.Round(thumbHeight / currentRatio);
                        }
                        break;
                    default:
                        break;
                }
            }
            String geomStr = thumbWidth.ToString() + "x" + thumbHeight.ToString()+"!";
            ImageMagick.MagickGeometry intermediateGeo = new ImageMagick.MagickGeometry(geomStr);
            srcImg.Thumbnail(intermediateGeo);
            srcImg.Crop(cropWidth, cropHeight, cropPosition);
            try
            {
                srcImg.Quality = quality;
                srcImg.Sharpen();
                srcImg.Write(dstPicPath);
            }
            catch (Exception e)
            {
                return "Create " + dstPicPath + " failure!\n Error:"+e.Message+"\n";
            }
            return "Create " + dstPicPath + " successfully!";
        }

        private void PictureTestButton_Click(object sender, EventArgs e)
        {
            string[] testPics = { @"F:\lady11\test1.jpg", @"F:\lady11\test2.jpg", @"F:\lady11\test3.jpg", @"F:\lady11\test4.jpg", @"F:\lady11\test5.jpg" };
            string dstRootPath = @"D:\testpic\thumbtest\";
            foreach (string testPic in testPics)
            {
                string thumbPath = dstRootPath + Path.GetFileNameWithoutExtension(testPic) + "_thumb.jpg";
                //string result = MakeThumb(testPic, thumbPath);
                //string result = MakeThumb(testPic, thumbPath, dstHeight: 300, mode: "H");
                string result = MakeThumbNew(testPic, thumbPath, 300, 300);
                textBox1.AppendText(result + "\n");
            }
        }
        #endregion

        #region 类, 面向对象测试
        private void ClassTestButton_Click(object sender, EventArgs e)
        {
            MiniVan myVan = new MiniVan("minivan",70);
            myVan.Speed = 120;
            textBox1.AppendText(string.Format("Myvan is going to speed {0}\n", myVan.Speed));
            textBox1.AppendText(string.Format("Myvan MaX speed {0}\n", myVan._maxSpeed));
            myVan.TestMethod();
            textBox1.AppendText(string.Format("Myvan is going to speed {0}\n", myVan.Speed));
            textBox1.AppendText(string.Format("myVan.tostring(): {0} \n", myVan.ToString()));
            textBox1.AppendText(string.Format("myVan.GetHashCode(): {0} \n", myVan.GetHashCode()));
        }

        private void InterfaceTestButton_Click(object sender, EventArgs e)
        {
            OperatingSystem systemOS = new OperatingSystem(PlatformID.Win32NT, new Version());
            textBox1.AppendText(string.Format("SytemOS: {0} \n", systemOS.ToString()));
            CloneMe(systemOS, textBox1);
            
            Car testCar = new Car("testcar",60);
            Car secondCar = (Car)testCar.Clone();
            textBox1.AppendText(string.Format("testCar is a : {0} :   Second Car  is a : {1} \n", testCar.GetType().Name, secondCar.GetType().Name));

            //通过标准接口实现枚举
            Garage carLot = new Garage();
            foreach (Car oneCar in carLot)
            {
                textBox1.AppendText(string.Format("Carname: {0} : CarMaxSpeed: {1} \n", oneCar.CarName, oneCar._maxSpeed));
            }

            //通过接口实现自定义类的排序
            textBox1.AppendText("通过接口实现自定义类的排序\n");
            Car[] carArray = new Car[4];
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 60);
            carArray[3] = new Car("Fred", 20);
            Array.Sort(carArray);
            foreach (Car oneCar in carArray)
            {
                textBox1.AppendText(string.Format("Carname: {0} : CarMaxSpeed: {1} \n", oneCar.CarName, oneCar._maxSpeed));
            }
            textBox1.AppendText("通过自定义排序接口实现自定义类的排序\n");
            Array.Sort(carArray, Car.SortByCarName);
            foreach (Car oneCar in carArray)
            {
                textBox1.AppendText(string.Format("Carname: {0} : CarMaxSpeed: {1} \n", oneCar.CarName, oneCar._maxSpeed));
            }

        }
        private static void CloneMe(ICloneable c,TextBox outputTbox)
        {
            object theClone = c.Clone();
            outputTbox.AppendText(string.Format("Your clone ia : {0} \n", theClone.GetType().Name));
        }
        #endregion

        #region 事件,委托测试
        private void EventTestButton_Click(object sender, EventArgs e)
        {
            Car testCar = new Car("EventCar", 120);
            //testCar.AboutToBlow += Car.CarAboutToBlow(textBox1);
            testCar.AboutToBlow += Car.CarAboutToBlow;
            testCar.destroyCar(textBox1);

            List<int> testList = new List<int> { 3, 8, 9, 10, 15, 17, 19, 21, 22, 25, 28, 31, 33, 37, 38 };
            //Predicate<int> callback = new Predicate<int>(isEvenNumber);
            //List<int> evenList = testList.FindAll(callback);
            //List<int> evenList = testList.FindAll(delegate (int x) { return x % 2 == 0; });
            List<int> evenList = testList.FindAll(x => (x %2)==0);
            foreach (int  item in evenList)
            {
                textBox1.AppendText(string.Format("Even number: {0} \n", item));
            }
            
        }
        static bool isEvenNumber(int i)
        {
            return i % 2 == 0;
        }
        #endregion

        private void AdvanceTestButton_Click(object sender, EventArgs e)
        {
            //扩展方法
            int testInt = 12345;
            int newInt = testInt.ReverseDigits();
            textBox1.AppendText(string.Format("testInt {0} after reversed:{1}\n", testInt, newInt));
            //使用传入参数构建匿名类型
            var car = new { Make = "Buick", Color = "Red", Speed = 120 };
            textBox1.AppendText(string.Format("匿名参数: {0} {1} {2}    {3}\n", car.Make, car.Color, car.Speed, car.ToString()));
        }
        #region Linsq测试
        private void LinqTestButton_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Linq测试:\n");
            int[] testLinq = { 3, 20, 15, 9, 12, 35, 28, 22, 68, 78 };
            var result = from num in testLinq
                         where num < 30
                         orderby num
                         select num;
            foreach (int item in result)
            {
                textBox1.AppendText(item.ToString() + "\n");
            }
            int[] subsetAsIntArray = (from i in testLinq where i < 30 orderby i select i).ToArray<int>();
            textBox1.AppendText("修改原始查询数据后(延迟执行):\n");
            testLinq[5] = 1;
            foreach (int item in result)
            {
                textBox1.AppendText(item.ToString() + "\n");
            }
            textBox1.AppendText("修改原始查询数据后(立即执行执行):\n");
            foreach (int item in subsetAsIntArray)
            {
                textBox1.AppendText(item.ToString() + "\n");
            }
            ArrayList myCars = new ArrayList() {
                new Car("BMW",200),
                new Car("Buick",180),
                new Car("Toyota",190),
                new Car("Honda",210),
                new Car("BYD",150)
            };
            textBox1.AppendText("立即执行的结果与原始查询数据的区别: \n");
            var diff = testLinq.Except(subsetAsIntArray);
            foreach (int item in diff)
            {
                textBox1.AppendText(item.ToString() + "\n");
            }
            var myCarsEnum = myCars.OfType<Car>();
            var fastCars = from c in myCarsEnum where c._maxSpeed > 160 orderby c.CarName select c;
            textBox1.AppendText("通过Linq查询非泛型类型数据:\n");
            foreach (Car item in fastCars)
            {
                textBox1.AppendText(string.Format("CarName: {0} Car Maxspeed: {1}\n", item.CarName, item._maxSpeed));
            }
        }
        #endregion

        #region  对象生命周期测试
        private void ObjectLifetimeTestButton_Click(object sender, EventArgs e)
        {
            System.Threading.Timer timer = new System.Threading.Timer(
                PrintMemory,
                null,
                0,
                1000);
            textBox1.AppendText("******测试System.GC*****\n");
            //输出堆上估计的字节数
            textBox1.AppendText(string.Format("堆上预估字节数 : {0}\n", GC.GetTotalMemory(false)));
            //输出程序所使用内存
            textBox1.AppendText(string.Format("程序所使用内存字节数 : {0}\n", Process.GetCurrentProcess().PrivateMemorySize64));
            //MaxGeneration 是从0开始的
            textBox1.AppendText(string.Format("This os has {0} object generations.\n", GC.MaxGeneration + 1));
            Car refToMyCar = new Car("Zippy", 100);
            textBox1.AppendText(refToMyCar.ToString() + "\n");
            //输出refToMyCar对象的代
            textBox1.AppendText(string.Format("Generation of refToMyCar is : {0}\n", GC.GetGeneration(refToMyCar)));
            //为测试目的创建对象数组
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
            {
                tonsOfObjects[i] = new object();
            }
            //仅回收第0代对象
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            //输出refToMyCar对象的代
            textBox1.AppendText(string.Format("对象 refToMyCar的代数: {0} \n", GC.GetGeneration(refToMyCar)));
            //看一下tonsOfObjects[9000]是否还活着
            if (tonsOfObjects[9000]!=null)
            {
                textBox1.AppendText(string.Format("tongsOfObjects[9000]的代数: {0}\n",GC.GetGeneration(tonsOfObjects[9000])));
            }
            else
            {
                textBox1.AppendText("tongsOfObjects[9000]不在堆中存在!\n");
            }
            //输出一个代被清除的次数
            textBox1.AppendText(string.Format("0 代被清除的次数 {0} \n", GC.CollectionCount(0)));
            textBox1.AppendText(string.Format("1 代被清除的次数 {0} \n", GC.CollectionCount(1)));
            textBox1.AppendText(string.Format("2 代被清除的次数 {0} \n", GC.CollectionCount(2)));
            
        }
        
        private void PrintMemory(object state)
        {
            this.Invoke((Action)delegate
            {
                labelCurrentProgramMem.Text = Process.GetCurrentProcess().PrivateMemorySize64.ToString();
                labelHeapMem.Text = GC.GetTotalMemory(false).ToString();
            });
        }
        #endregion

        #region 程序集测试
        private void assemblyTestButton_Click(object sender, EventArgs e)
        {
            Assembly currentAsm = Assembly.GetExecutingAssembly();
            string[] currentManifestResourceNames = currentAsm.GetManifestResourceNames();
            textBox1.AppendText("当前程序集的ManifestResourceNames 数组:\n");
            foreach (string item in currentManifestResourceNames)
            {
                textBox1.AppendText(item + "\n");
            }
            //测试晚期绑定
            try
            {
                Assembly asmTest = Assembly.Load("SimpleMathLib");
                if (asmTest!=null)
                {
                    textBox1.AppendText(string.Format("测试程序集名称: {0}\n", asmTest.FullName));
                    Type simpleMath = asmTest.GetType("SimpleMathLib.SimpleMath");
                    /*
                    object obj = Activator.CreateInstance(simpleMath);
                    textBox1.AppendText(string.Format("Created a {0} using late binding! \n", obj));
                    MethodInfo simpleAdd = simpleMath.GetMethod("Add");
                    int addResult = (int)simpleAdd.Invoke(obj, new object[] { 10, 20 });
                    textBox1.AppendText(string.Format("晚期绑定,调用SimpleMathLib命名空间中SimpleMath类 Add方法计算结果: {0} \n", addResult));
                    */
                    dynamic obj = Activator.CreateInstance(simpleMath);
                    textBox1.AppendText(string.Format("晚期绑定使用动态类型调用,SimpleMathLib命名空间中SimpleMath类 Add方法计算结果: {0} \n", obj.Add(10, 20)));
                }
            }
            catch (Exception ex)
            {
                textBox1.AppendText(string.Format("Error: {0}\n", ex.Message));
                return;
            }
            //枚举加载的程序集
            AppDomain defaultAD = AppDomain.CurrentDomain;
            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            textBox1.AppendText(string.Format("以下是当前应用程序 {0} 加载的程序集\n", defaultAD.FriendlyName));
            foreach (Assembly asm in loadedAssemblies)
            {
                textBox1.AppendText(string.Format("Name: {0} \n", asm.GetName().Name));
                textBox1.AppendText(string.Format("Vsersion:{0}\n", asm.GetName().Version));
            }

        }
        #endregion

        #region 进程测试
        private void ProcessTestButton_Click(object sender, EventArgs e)
        {
            int currentProcessID = Process.GetCurrentProcess().Id;
            EnumModsForPid(currentProcessID);
        }
        private void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (Exception ex)
            {
                textBox1.AppendText(string.Format("Error Message: {0} \n", ex.Message));
                return;
            }
            textBox1.AppendText(string.Format("下面是ID为 {0} 进程名字为{1} 的进程所加载的模块: \n",pID,theProc.ProcessName));
            ProcessModuleCollection theMods = theProc.Modules;
            foreach (ProcessModule item in theMods)
            {
                textBox1.AppendText(string.Format("模块名称: {0}  占用内存: {1}\n", item.ModuleName,item.ModuleMemorySize));
            }
        }
        #endregion

        #region 多线程测试 , 使用委托实现异步
        private delegate int BinaryOP(int x);

        private void MultiThreadTestButton_Click(object sender, EventArgs e)
        {
            //通过backgroundWorker控件实现异步
            backgroundWorkerOutput.RunWorkerAsync();
            backgroundWorker1.RunWorkerAsync();

            //通过委托实现异步
            BinaryOP simpleAddTest = new BinaryOP(SimpleAdd);
            simpleAddTest.BeginInvoke(2000,SimpleAddComplete,2000);
            /*
            IAsyncResult itfAR = simpleAddTest.BeginInvoke(10000, null, null);
            textBox1.AppendText("主线程继续做更多工作!\n");
            int answer = simpleAddTest.EndInvoke(itfAR);
            textBox1.AppendText(string.Format("简单累计相加测试结果(从1累加到 10000): {0}\n", answer));
            */
            //任务并行库测试

        }
        //通过委托实现异步测试
        private int SimpleAdd(int x)
        {
            int addResult = 0;
            for (int i = 0; i < x; i++)
            {
                //Thread.Sleep(1);
                addResult += i;
                //textBox1.AppendText(string.Format("当前计算位置:{0}\n", i));
                
                this.Invoke((Action)delegate {
                    this.textBox1.AppendText(string.Format("当前计算位置:{0}\n", i));
                });
                
            }
            return addResult;
        }
        private void SimpleAddComplete(IAsyncResult itfAR)
        {
            int countNum = (int)itfAR.AsyncState;
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOP simpleAddTest = (BinaryOP)ar.AsyncDelegate;
            int addResult = simpleAddTest.EndInvoke(itfAR);
            //textBox1.AppendText(string.Format("简单累计相加测试结果(从1累加到 {0}): {1}\n", countNum,addResult));
            
            this.Invoke((Action)delegate {
                this.textBox1.AppendText(string.Format("简单累计相加测试结果(从1累加到 {0}): {1}\n", countNum, addResult));
            });
            
        }

        //backgroundWorker控件测试
        private void backgroundWorkerOutput_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.AppendText("完成background调用!\n");
        }
        private void backgroundWorkerOutput_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress(i * 10, i);
            }
        }
        private void backgroundWorkerOutput_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            int position = (int)e.UserState;
            textBox1.AppendText(position.ToString() + "\n");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress(i * 1, i);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel2.Text = (e.ProgressPercentage.ToString() + "%");
            int position = (int)e.UserState;
            textBox1.AppendText(position.ToString() + "\n");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.AppendText("完成background调用!\n");
        }



        #endregion

        #region 多线程测试2  task类
        private void multiThreadTest2Button_Click(object sender, EventArgs e)
        {
            //使用task类实现多线程
            Task.Factory.StartNew(() =>{
                int countNum = 2000;
                SimpleAddWithTask(countNum);
                /*
                this.Invoke((Action)delegate {
                    this.textBox1.AppendText(string.Format("简单累计相加测试结果(从1累加到 {0}): {1}\n", countNum, result));
                });
                */
                //通过backgroundWorker控件实现异步
            });
            backgroundWorkerOutput.RunWorkerAsync();
            backgroundWorker1.RunWorkerAsync();
        }
        private void SimpleAddWithTask(int x)
        {
            int addResult = 0;
            for (int i = 0; i < x; i++)
            {
                //Thread.Sleep(1);
                addResult += i;
                //textBox1.AppendText(string.Format("当前计算位置:{0}\n", i));

                this.Invoke((Action)delegate {
                    this.textBox1.AppendText(string.Format("当前计算位置:{0}\n", i));
                });
            }
        }
        #endregion

        #region 多线程测试3 并行处理库以及linq的并行处理
        private void multiThreadTest3Button_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
            Task testTask = new Task(ProcessIntData);
            testTask.Start();
        }
        private void ProcessIntData()
        {
            //获得一个非常大的整数数组
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            //找到num%3==0为true的数字, 降序返回
            int[]modThreeIsZero = (from num in source.AsParallel()
                       where num % 3 == 0
                       orderby num descending
                       select num).ToArray();
            this.Invoke((Action)delegate
            {
                this.textBox1.AppendText(string.Format("找到{0} 个能被3整除的数字\n", modThreeIsZero.Count()));
            });
        }
        #endregion

        #region 多线程测试4 async 和 await

        private async void multiThreadTest4Button_Click(object sender, EventArgs e)
        {
            CancelTokenSource = new CancellationTokenSource();
            CancellationToken ct = CancelTokenSource.Token;
            this.Text = await DoWorkAsync(ct);
            textBox1.AppendText(string.Format("正在测试async和awaite!\n"));
            Car testCar = new Car("Testcar", 100, "Blue");
            /*
            if (!ct.IsCancellationRequested)
            {
                Car NewCar = await CarTestAsync(testCar, ct);
                textBox1.AppendText(string.Format("CarName: {0} CarMaxSpeed:{1} CarSpeed:{2}  CarColor:{3} \n", NewCar.CarName, NewCar._maxSpeed, NewCar.Speed, NewCar.CarColor));
            }
            */
            try
            {
                Car NewCar = await CarTestAsync(testCar, ct);
                textBox1.AppendText(string.Format("CarName: {0} CarMaxSpeed:{1} CarSpeed:{2}  CarColor:{3} \n", NewCar.CarName, NewCar._maxSpeed, NewCar.Speed, NewCar.CarColor));
            }
            catch (Exception ex)
            {
                textBox1.AppendText(ex.Message + "\n");
            }
        }
        private async Task<string> DoWorkAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                /*
                for (int i = 0; i < 5000; i++)
                {
                    Thread.Sleep(1);
                    if (ct.IsCancellationRequested)
                    {
                        return "用户已取消当前任务!";
                    }
                }
                */
                try
                {
                    /*
                    for (int i = 0; i < 5000; i++)
                    {
                        Thread.Sleep(1);
                        ct.ThrowIfCancellationRequested();
                    }
                    */
                    bool cancelled = ct.WaitHandle.WaitOne(5000);
                    if (cancelled)
                    {
                        throw new OperationCanceledException(ct);
                    }
                    return "Done with work!";
                }
                catch (OperationCanceledException ex)
                {
                    return "当前任务已经被取消!";
                }
            },ct);
        }
        private async Task<Car> CarTestAsync(Car testCar,CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                /*
                for (int i = 0; i < 5000; i++)
                {
                    Thread.Sleep(1);
                    if (ct.IsCancellationRequested)
                    {
                        return testCar;
                    }
                }
                */
                try
                {
                    bool cancelled = ct.WaitHandle.WaitOne(5000);
                    if (cancelled)
                    {
                        throw new OperationCanceledException(ct);
                    }
                    testCar.Speed = 10000;
                    return testCar;
                }
                catch (OperationCanceledException ex)
                {
                    return testCar;
                }
            },ct);
        }
        #endregion

        #region 多线程测试 Task类测试
        private  async void multiThreadTaskButton_Click(object sender, EventArgs e)
        {
            //-----------------多个await任务-----------------------------------------------------------------------------------
            /*两步异步调用
            Task multiAwaitTestTask = MultiAwaitTest();
            await multiAwaitTestTask;
            */
            //单步异步调用
            await MultiAwaitTest();
            //-------------------异步下载--------------------------------------------------------------------------------------
            await CachedDownloadTest();
            //-------------------微软演示Task.WhenAll--------------------------------------------------------------------------------------
            await SumPageSizesAsync();
        }

        private async Task MultiAwaitTest()
        {
            //-----------------多个await任务-----------------------------------------------------------------------------------
            double[] param = new double[3] { 1.0, 100.0, 1000.0 };
            double[] results = new double[3];
            /*
            double sum = 0;
            for (int i = 0; i < results.Length; i++)
            {
                //results[i] = taskArray[i].Result;
                //results[i] = await Task.Run(() => DoComputation(param[i]));
                results[i] = await DoComputationAsync(param[i]);
                this.Invoke((Action)delegate {
                    textBox1.AppendText(string.Format("{0:N1}{1}",results[i],i==results.Length-1?"=":"+"));
                });
                sum += results[i];
            }
            textBox1.AppendText(string.Format("{0:N1}\n", sum));
            */
            var addTask = from number in param
                          select DoComputationAsync(number);
            double[] addResults = await Task.WhenAll(addTask);
            for (int i = 0; i < addResults.Length; i++)
            {
                textBox1.AppendText(string.Format("{0:N1}{1}", addResults[i], i == addResults.Length - 1 ? "=" : "+"));
            }
            textBox1.AppendText(string.Format("{0:N1}\n", addResults.Sum()));
        }
        //多个await任务 调用的task任务
        private async static Task<double> DoComputationAsync(double start)
        {
            return await Task.Run(() =>
            {
            double sum = 0;
            //for (var value = start;  value <= start+100 ; value+=.1)
            for (var value = start;  value <= start+10000 ; value+=.1)
            {
                sum += value;
                //Thread.Sleep(10);
            }
            return sum;
            });
        }

        private async Task CachedDownloadTest()
        {
            //-------------------异步下载--------------------------------------------------------------------------------------
            string[] urls = new string[]
            {
                 "http://msdn.microsoft.com",
                 "http://www.contoso.com",
                 "http://www.microsoft.com"
            };
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //string resultDownload = await DownloadStringAsync(urls[0]);
            //string[] resultDownloads = new string[urls.Length];
            //int downloadSum = 0;
            /*
            for (int i = 0; i < urls.Length; i++)
            {
                resultDownloads[i] = await DownloadStringAsync(urls[i]);
                downloadSum += resultDownloads[i].Length;
            }
            stopwatch.Stop();
            textBox1.AppendText(string.Format("收到{0}字符, 使用时间{1} ms.\n", downloadSum, stopwatch.ElapsedMilliseconds));
            */
            var downloads = from url in urls
                            select DownloadStringAsync(url);
            /*
            await Task.WhenAny(downloads).ContinueWith(downloadResults=>
            {
                stopwatch.Stop();
                this.Invoke((Action)delegate
                {
                    textBox1.AppendText(string.Format("收到{0}字符, 使用时间{1} ms.\n", downloadResults.Result.Result, stopwatch.ElapsedMilliseconds));
                });
            });
            return;
            */
            string[] taskResults = await Task.WhenAll(downloads);
            stopwatch.Stop();
            textBox1.AppendText(string.Format("收到{0} 字符 , 使用时间 {1} ms.\n", taskResults.Sum(result => result.Length), stopwatch.ElapsedMilliseconds));

            /*
            await Task.WhenAll(downloads).ContinueWith(downloadResults=> {
                stopwatch.Stop();
                this.Invoke((Action)delegate
                {
                    textBox1.AppendText(string.Format("收到{0}字符, 使用时间{1} ms.\n", downloadResults.Result.Sum(result =>result.Length), stopwatch.ElapsedMilliseconds));
                });
            });
            */
            //再执行一次下载, 这一次下载所使用的时间应该比第一次要少很多,因为缓存中已经有下载结果了
            stopwatch.Restart();
            downloads = from url in urls
                        select DownloadStringAsync(url);
            await Task.WhenAll(downloads).ContinueWith(downloadResults => {
                stopwatch.Stop();
                this.Invoke((Action)delegate
                {
                    textBox1.AppendText(string.Format("收到{0}字符, 使用时间{1} ms.\n", downloadResults.Result.Sum(result => result.Length), stopwatch.ElapsedMilliseconds));
                });
            });
            //string resultDownload = await DownloadStringAsync(urls[0]);
            /*
            resultDownloads = new string[urls.Length];
            downloadSum = 0;
            for (int i = 0; i < urls.Length; i++)
            {
                resultDownloads[i] = await DownloadStringAsync(urls[i]);
                downloadSum += resultDownloads[i].Length;
            }
            stopwatch.Stop();
            textBox1.AppendText(string.Format("收到{0}字符, 使用时间{1} ms.\n", downloadSum, stopwatch.ElapsedMilliseconds));
            */
        }
        //演示如何使用Task<Tresult>.FromResult 来建立task任务, 演示通过缓冲下载任务达到加速模拟
        static ConcurrentDictionary<string, string> cachedDownloads =
            new ConcurrentDictionary<string, string>();
        //异步讲请求的资源下载为字符串
        public async static Task<string>DownloadStringAsync(string address)
        {
            string content;
            if (cachedDownloads.TryGetValue(address,out content))
            {
                return await Task.FromResult<string>(content);
            }
            //如果请求的下载没有被下载过, (即cachedDownloads字典中不存在对应的值), 则请求下载
            return await Task.Run(async() =>
            {
                content = await new WebClient().DownloadStringTaskAsync(address);
                cachedDownloads.TryAdd(address, content);
                return content;
            });

        }

        //-------------------MSDN演示 Task.WhenAll--------------------------------------------------------------------------------------
        private async Task SumPageSizesAsync()
        {
            List<string> urls = new List<string>
            {
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
               };
            /*var downloadTaskQuery = from url in urls
                                    select ProcessURLAsync(url);
            */
            HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            var downloadTaskQuery = from url in urls
                                    select ProcessURLAsync(url, client);
            int[] lengths = await Task.WhenAll(downloadTaskQuery);
            int total = lengths.Sum();
            textBox1.AppendText(string.Format("总下载字节数: {0} \n", total));
        }
        private async Task<int> ProcessURLAsync(string url, HttpClient client=null)
        {
            byte[] byteArray = null;
            if (client==null)
            {
                byteArray = await GetURLContentsByWebrequestAsync(url);
            }
            else
            {
                byteArray = await GetURLContentByHttpclientAsync(url, client);
            }
            DisplayResults(url, byteArray);
            return byteArray.Length;
        }
        private async Task<byte[]> GetURLContentsByWebrequestAsync(string url)
        {
            var content = new MemoryStream();
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }
            return content.ToArray();
        }
        private async Task<byte[]>GetURLContentByHttpclientAsync(string url, HttpClient client)
        {
            byte[] byteArray = await client.GetByteArrayAsync(url);
            return byteArray;
        }
        private void DisplayResults(string url, byte[] content)
        {
            var bytes = content.Length;
            var displayURL = url.Replace("http://", "");
            textBox1.AppendText(string.Format("{0,-58},{1,8}\n", displayURL, bytes));
        }

        #endregion


        #region 取消测试
        private CancellationTokenSource CancelTokenSource;
        private void cancelTestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消当前正在运行的任务?","确认",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                CancelTokenSource.Cancel();
            }
        }
        #endregion

        #region 文件输入输出测试
        private void FileTestButton_Click(object sender, EventArgs e)
        {
            //基本信息的测试
            DirectoryInfo testDir = new DirectoryInfo(@"D:\testpic\modified");
            Directory.CreateDirectory(@"D:\testpic\testCreateDir");
            FileInfo[] testFiles = testDir.GetFiles("*.jpg", SearchOption.AllDirectories);
            textBox1.AppendText("***Directory info******\n");
            textBox1.AppendText(string.Format("FullName: {0}\n", testDir.FullName));
            textBox1.AppendText(string.Format("Name: {0}\n", testDir.Name));
            textBox1.AppendText(string.Format("Parent: {0}\n", testDir.Parent));
            textBox1.AppendText(string.Format("Creation: {0}\n", testDir.CreationTime));
            textBox1.AppendText(string.Format("Attributes: {0}\n", testDir.Attributes));
            textBox1.AppendText(string.Format("Root: {0}\n", testDir.Root));
            textBox1.AppendText("***************************\n");
            textBox1.AppendText(string.Format("Found {0} *.jpg files.\n\n", testFiles.Length));

            FileInfo f = testFiles[0];
            textBox1.AppendText("**************************\n");
            textBox1.AppendText("打印指定目录下找到的jpg文件中的其中一个文件详细信息: \n");

            textBox1.AppendText(string.Format("File Name: {0} \n", f.Name));
            textBox1.AppendText(string.Format("File size: {0}\n", f.Length));
            textBox1.AppendText(string.Format("Creation: {0} \n", f.CreationTime));
            textBox1.AppendText(string.Format("Attributes: {0}\n", f.Attributes));
            textBox1.AppendText("***************************\n");

            /*
            foreach (FileInfo f in testFiles)
            {
                await Task.Run(() => {
                    this.Invoke((Action)delegate
                    {
                        textBox1.AppendText("**************************\n");
                        textBox1.AppendText(string.Format("File Name: {0} \n", f.Name));
                        textBox1.AppendText(string.Format("File size: {0}\n", f.Length));
                        textBox1.AppendText(string.Format("Creation: {0} \n", f.CreationTime));
                        textBox1.AppendText(string.Format("Attributes: {0}\n", f.Attributes));
                        textBox1.AppendText("***************************\n");
                    });
                    Thread.Sleep(10);
                });
            }
            */
            //文件流(fileStream)测试
            FileStreamTest("Hello,钟海城");
            //StreamReader & StreamWriter 测试
            StreamTest(@"http://www.yaoyaolady.com");
            //BinaryReader & BinaryWriter 测试
            BinaryTest();
            //对象序列化测试
            SerializeTest();
        }
        //FileStreamTest 测试
        private void FileStreamTest(string message)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FileStreamTest.txt";
            textBox1.AppendText("测试FileSteam类\n");
            using (FileStream fs= File.OpenWrite(savePath))
            {
                byte[] msgAsByteArray = Encoding.UTF8.GetBytes(message);
                fs.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                textBox1.AppendText(string.Format("写入文件字节数: {0}\n", msgAsByteArray.Length));
            }
            textBox1.AppendText("写入文件测试完毕\n");
            using (FileStream fs = File.OpenRead(savePath))
            {
                byte[] msgAsByteArray = new byte[fs.Length];
                fs.Read(msgAsByteArray, 0, msgAsByteArray.Length);
                textBox1.AppendText("从测试文件中读取的内容为:\n");
                textBox1.AppendText(Encoding.UTF8.GetString(msgAsByteArray)+"\n");
            }
        }
        //StreamWriter & StreamReader & WebRequest 测试
        private void StreamTest(string url)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FileStreamTest.txt";
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
            using (WebResponse response = webReq.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        string testText = sReader.ReadToEnd();
                        textBox1.AppendText(testText + "\n");
                        using (StreamWriter sWriter=new StreamWriter(savePath))
                        {
                            sWriter.Write(testText);
                        }
                    }
                }
            }
        }
        //BinaryReader & BinaryWriter 测试
        private void BinaryTest()
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\BinData.dat";
            using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(savePath)))
            {
                //输出BaseStream的类型, 这里是System.IO.FileStream
                textBox1.AppendText(string.Format("BaseStream is : {0} \n", bw.BaseStream));
                double aDouble = 1234.567;
                int anInt = 34567;
                string aString = "A, B, C";
                //写数据
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }
            textBox1.AppendText("BinaryWriter测试写入数据完毕!\n");
            using (BinaryReader br = new BinaryReader(File.OpenRead(savePath)))
            {
                textBox1.AppendText(br.ReadDouble() + "\n");
                textBox1.AppendText(br.ReadInt32() + "\n");
                textBox1.AppendText(br.ReadString() + "\n");
            }
            textBox1.AppendText("BinaryReader测试读取数据完毕!\n");

        }

        //对象序列化测试
        [Serializable]
        public class UserPrefs
        {
            public string WindowColor;
            public int FontSize;
            public string[] Username;
            public int[] MemSize;
            public UserPrefs()
            {
                WindowColor = "Red";
                FontSize = 12;
                Username = new string[] { "Nobody","Administrator","www"};
                MemSize = new int[] { 4, 8, 16, 32, 64 };
            }
        }
        private void SerializeTest()
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 16;
            string binSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\binFormat.dat";
            string xmlSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\xmlFormat.xml";
            //使用BinaryFormatter以二进制格式持久化状态数据
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fsStream = File.OpenWrite(binSavePath))
            {
                binFormat.Serialize(fsStream, userData);
            }
            XmlSerializer xmlFormat = new XmlSerializer(typeof(UserPrefs));
            using (Stream fsStream = File.OpenWrite(xmlSavePath))
            {
                xmlFormat.Serialize(fsStream, userData);
            }

        }

        #endregion

    }
}
