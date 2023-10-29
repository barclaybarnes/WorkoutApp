using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Project_GUI_1._0
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
        }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; //Add Mac Operating System Compatible version later
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Create Workout Button
        {
            DialogResult dr = MessageBox.Show("Do you want to create a new Workout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) 
            {
                tabControl1.SelectedIndex = 1;
            }     
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e) // View Workouts Button Calls General Path + Visual Studio Files
        {
            Process.Start(path+"\\bin\\debug\\WorkoutList.txt");
        }

        private void button1_Click_2(object sender, EventArgs e) //Code Works outside of this yet does not work when allocating the console here? I need a fix for this to move forward with the chatbot function of the app
        {
            
                AllocConsole();

                Console.WriteLine("Welcome to the Workout Generator App! \n");

                Console.WriteLine("Below are a list of our Frequently Asked Questions:");

                int MenuInt = 0;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine
                       ("\n" +
                        "1) What are the benefits of being Active?\n" +
                        "2) Can I tailor my Workout to my preferences or fitness goals?\n" +
                        "3) Is there a variety of workout options available, or does the app offer a specific type of workout?\n" +
                        "4) Are there video demonstrations or detailed instructions for each exercise in the generated workout?\n" +
                        "5) Can I sync the app with my smart devices or wearables to monitor my physical activity throughout the day?\n" +
                        "6) Are there instructional videos or guides to ensure I'm performing exercises with proper form and technique?\n" +
                        "7) Link to a Short Video explaining use of the Application\n" +
                        "8) Stop");


                    MenuInt = 0;
                    MenuInt = Convert.ToInt32(Console.ReadLine());


                    switch (MenuInt)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Benefits include improved thinking or cognition for children 6 to 13 years of age and reduced short-term feelings of anxiety for adults.\n Regular physical activity can help keep your thinking, learning, and judgment skills sharp as you age. It can also reduce your risk of depression and anxiety and help you sleep better.");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n You can tailor your workout to your preferences or your fitness goals.\n There is a wide variety of workout options available depending on what your goals are ranging from simply walking to weight lifting");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n There is a wide variety of workout options available depending on your personal preferences and what you want to acheive. \n This can range from: \n Weightlifting \n Walking or Running \n Sports \n Yoga \n etc...");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Yes, there is either a video demonstration of the workout or a detailed description of the workout");
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n No, the functionality that is currently available does not allow the app to be synced with smart devices to track activity.");
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Yes, there are in some cases videos or detailed instruction there to ensure the proper form and technique");
                            break;
                        case 7:
                            {

                                string url = "http://google.com";


                                try
                                {
                                    Process.Start(url);
                                }
                                catch
                                {
                                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                                    {
                                        url = url.Replace("&", "^&");
                                        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                                    }
                                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                                    {
                                        Process.Start("xdg-open", url);
                                    }
                                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                                    {
                                        Process.Start("open", url);
                                    }
                                    else
                                    {
                                        throw;
                                    }
                                }
                            }
                            break;
                        case 8:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Thank you for using our Frequently Asked Questions feature.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                } while (MenuInt != 8);







            
        }
        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Swapping Pages to Create Workout Page
        {
            tabControl1.SelectedIndex = 0;
        }
       
        private void button3_Click(object sender, EventArgs e) //Creating New Set
        {
            DialogResult dr = MessageBox.Show("Do you want to create a new Set?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dr == DialogResult.Yes)
            {
                if (!File.Exists("WorkoutList.txt")) // If file does not exists
                {
                    File.Create("WorkoutList.txt").Close(); // Create file
                    using (StreamWriter sw = File.AppendText("WorkoutList.txt"))
                    {
                        sw.WriteLine(textBox3.Text); // Write text to .txt file
                        sw.WriteLine(textBox1.Text + " Sets");
                        sw.WriteLine("Of " + textBox4.Text + " Reps\n");
                    }
                }
                else // If file already exists
                {
                    // File.WriteAllText("FILENAME.txt", String.Empty); // Clear file
                    using (StreamWriter sw = File.AppendText("WorkoutList.txt"))
                    {
                        sw.WriteLine(textBox3.Text); // Write text to .txt file
                        sw.WriteLine(textBox1.Text + " Sets");
                        sw.WriteLine("Of " + textBox4.Text + " Reps\n");
                        
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //Delete Workouts Function (Deletes all Text within Document)
        {
            DialogResult dr = MessageBox.Show("This will Delete All Previous Workouts. Are you sure you want to proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                File.WriteAllText(path + "\\bin\\debug\\WorkoutList.txt", String.Empty);
            }
        }
    }
}

