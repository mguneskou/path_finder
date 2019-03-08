using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace find_path_visual
{
    public partial class Form1 : Form
    {
        int width = 64, height = 64;//initial width, height values
        Timer t;//renderer
        Graphics g_character;//will draw the character
        Bitmap character;//character's bitmap will assigned to image property of the picturebox
        SolidBrush c_brush = new SolidBrush(Color.Red);//character's colour
        Point current_location, next_location;//character's location
        bool game_over = false;//controls the renderer
        List<Point> path = new List<Point>();//found path
        int x_factor = 10, y_factor = 10;//aspect ratio
        
        public Form1()
        {
            InitializeComponent();
            t = new Timer();
            t.Interval = 100;//frame rate, 10 fps at the moment
            t.Tick += render;//event handler for timer's tich event
        }

        private void render(object sender, EventArgs e)//updates character's position 10 times every second
        {
            if(!game_over)//if game_over flag is false
            {
                if(current_location.Y >= height * y_factor - y_factor)//character has found the path to bottom
                {
                    t.Stop();//path found stop the timer
                    MessageBox.Show("Path found!");
                    btn_find_path.Enabled = false;//disable the start button
                    btn_generate_map.Enabled = true;//enable the map generation button
                    game_over = true;//set game_over flag to true
                    lst_path.DataSource = path;//fill listbox with path information
                }
                else//character still trying to find the path to bottom
                {
                    find_next_move();//gets the next possible position, if there is no any sets the game_over flag as true
                    current_location = next_location;
                    path.Add(current_location);//add the found location to the list
                    g_character.FillRectangle(c_brush, new Rectangle(current_location, new Size(x_factor, y_factor)));//draw the character into next position
                    pb.Image = character;//set picturebox's image property
                }
            }
            else
            {
                t.Stop();
                MessageBox.Show("No more moves, renew the map!");//there is no move
                btn_find_path.Enabled = false;//disable the start button
                btn_generate_map.Enabled = true;//enable the map generation button
            }
        }

        void find_next_move()//finds possible next move, tends to move down first, if not possible tries right, then tries left
        {
            if(Map_generator.clear_path.Exists(o => o.Y == current_location.Y + y_factor && o.X == current_location.X))//first try to move straight down
            {
                next_location = Map_generator.clear_path.Find(o => o.Y == current_location.Y + y_factor && o.X == current_location.X);//next location of character is bottom of the current location
            }
            else if(Map_generator.clear_path.Exists(o => o.Y == current_location.Y && o.X == current_location.X + x_factor))//if not try the right one
            {
                if(current_location.X < width * x_factor - x_factor)//is character is not on the right border of the picturebox
                {
                    next_location = Map_generator.clear_path.Find(o => o.Y == current_location.Y && o.X == current_location.X + x_factor);//next location of character is the right of the current location
                }
            }
            else if (Map_generator.clear_path.Exists(o => o.Y == current_location.Y - y_factor && o.X == current_location.X))//if not try the up one
            {
                current_location.Y = current_location.Y - y_factor;//move one pixel back
                if (Map_generator.clear_path.Exists(o => o.Y == current_location.Y && o.X == current_location.X + x_factor))//check right
                {
                    next_location = Map_generator.clear_path.Find(o => o.Y == current_location.Y && o.X == current_location.X + x_factor);//next location of character is right of the current location
                }
                else if (Map_generator.clear_path.Exists(o => o.Y == current_location.Y && o.X == current_location.X - x_factor))//check left
                {
                    next_location = Map_generator.clear_path.Find(o => o.Y == current_location.Y && o.X == current_location.X - x_factor);//next location of character is left of the current location
                }
            }
            else if(Map_generator.clear_path.Exists(o => o.Y == current_location.Y && o.X == current_location.X - x_factor))//next move is the left
            {
                if (current_location.X > 0)//if character is not on the left border of the picturebox
                {
                    next_location = Map_generator.clear_path.Find(o => o.Y == current_location.Y && o.X == current_location.X - x_factor);//next location of character is the left of the current location
                }
            }
            else
            {
                
            }
        }

        private void txt_width_TextChanged(object sender, EventArgs e)
        {
            txt_height.Text = txt_width.Text;//for keeping aspect ration constant, txt_height is disabled
        }

        //starts the game
        private void btn_find_path_Click(object sender, EventArgs e)
        {
            btn_generate_map.Enabled = false;
            btn_generate_map.Enabled = false;
            t.Start();
        }

        //prepares map
        private void btn_generate_map_Click(object sender, EventArgs e)
        {
            if (game_over)//if game is over then reset the variables
            {
                //reset all variables
                game_over = false;//new game starts
                current_location = new Point(0, 0);//current lcoation is 0, 0
                next_location = new Point(0, 0);//next lcoation is 0, 0
                Map_generator.clear_path.Clear();//clear path should be emptied before filling with new locations
                Map_generator.obstacles.Clear();//obstacles should be emptied before filling with new locations
                Array.Clear(Map_generator.map, 0, Map_generator.map.Length);//map is being cleared
                g_character.Clear(Color.Transparent);//character's path is being cleared
                path.Clear();
                pb.Image = character;
                //reset all variables
            }
            width = Convert.ToInt32(txt_width.Text);//set width
            height = Convert.ToInt32(txt_height.Text);//set height
            x_factor = pb.Width / width;//get the aspect ratio
            y_factor = pb.Height / height;//get the aspect ratio
            character = new Bitmap(width * x_factor, height * y_factor);//create the character bitmap
            g_character = Graphics.FromImage(character);//create the character graphics object
            g_character.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;//for faster rendering
            Map_generator.generate_map(width, height, x_factor, y_factor);//generate the map
            pb.BackgroundImage = Map_generator.bmp;//assign the map to the picturebox as background image
            btn_generate_map.Enabled = false;//disable map generation button
            btn_find_path.Enabled = true;//enable path find button
        }
    }

    internal static class Map_generator//static class generates map and draws on bitmap
    {
        internal static int[,] map;//map variable
        internal static List<Point> obstacles = new List<Point>();//obstacles list of points
        internal static List<Point> clear_path = new List<Point>();//clear path list of points
        static Random rnd = new Random();//random number generator for map creation

        internal static Graphics g;//draws the obstacle rectangles on the bitmap
        internal static Bitmap bmp;//map bitmap as background image of the picturebox
        internal static SolidBrush brush;//obstacles are black by default

        /// <summary>
        /// Generates map with given parameters
        /// </summary>
        /// <param name="width">Width of the map in pixels</param>
        /// <param name="height">Height of the map in pixels</param>
        /// <param name="x_factor">x aspect ratio</param>
        /// <param name="y_factor">y aspect ratio</param>
        internal static void generate_map(int width, int height, int x_factor, int y_factor)
        {
            bmp = new Bitmap(width * x_factor, height * y_factor);//map bitmap gets new size
            g = Graphics.FromImage(bmp);//graphics object is created
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;//for high speed
            brush = new SolidBrush(Color.Black);//default colour of obstacles is black
            g.Clear(Color.White);//clears the bitmap to picturebox's backcolor
            map = new int[width, height];//we store the 0 and 1 information in this variable

            for (int y = 0; y < height; y++)//rows
            {
                for (int x = 0; x < width; x++)//columns
                {
                    if(y > 1 && y % 5 == 0 || y % 4 == 0)//let obstacles come at every 4th and 5th row
                    {
                        map[y, x] = rnd.Next(0, 2);//get next random number 0-1
                        if (map[y, x] == 1)//if it is 1
                        {
                            g.FillRectangle(brush, new Rectangle(new Point(x * x_factor, y * y_factor), new Size(x_factor, y_factor)));//draw the obstacle on bitmap
                        }
                    }
                    //at every iteration of for loops checks the map information and places the obstacles and clear path into related lists
                    if (map[y, x] == 1)
                    {
                        obstacles.Add(new Point(x * x_factor, y * y_factor));
                    }
                    else
                    {
                        clear_path.Add(new Point(x * x_factor, y * y_factor));
                    }
                }
            }
        }
    }
}