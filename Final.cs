using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


    class Final
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If you want to close the window, press the ESC Key");

            MyWindow window = new MyWindow();
            window.Run();
            Console.WriteLine("Finished");
        }
    }

    class MyWindow
    {
        RenderWindow window;
        Clock clock;

        Time delta;

        LinkedList_Code<BlueBall> balls;
        float circleSize;

        Random random;
        float speed;

        Font font;
        Text text;



        public MyWindow()
        {
            VideoMode mode = new VideoMode(1600, 900);
            window = new RenderWindow(mode, "Final Assignment SFML.NET", Styles.Titlebar);

            window.Closed += this.Window_close;
            window.KeyPressed += this.Key_press;
            window.MouseButtonPressed += this.Mouse_press;

            clock = new Clock();
            delta = Time.Zero;

            balls = new LinkedList_Code<BlueBall>();
            circleSize = 30f;

            random = new Random();
            speed = 350f;

            font = new Font(@"C:\\Windows\Fonts\Arial.ttf");
            text = new Text("If you want to add the node, do left-click or else if,\nIf you want to remove the node, do right-click or else\n, Press Space or Esc to exit.", font, 25);
            
        }

        
        public void Run()
        {
            while (window.IsOpen)
            {
                this.Update();
                this.Display();
            }
        }
        //public void getData()
        //{
        //    return data;
        //}

        public void Update()
        {
            window.DispatchEvents();

            delta = clock.Restart();

            this.UpdateCircles();
        }

        public void Display()
        {
            
            window.Clear();

            
            this.DrawCircles();

            /// draw the help text
            window.Draw(text);

            /// display the window to the screen
            window.Display();
        }


        
        public void Key_press(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            
            switch(e.Code)
            {
                case Keyboard.Key.Escape:
                    window.Close();
                    break;
                case Keyboard.Key.Space:
                    window.Close();
                    break;
                default:
                    break;
            }


        }

        public void Mouse_press(object sender, MouseButtonEventArgs e)
        {
            switch(e.Button)
            {
                case Mouse.Button.Left:
                    this.addTheBall(e.X, e.Y);
                   
                    break;
                case Mouse.Button.Right:
                    this.balls.Dequeue();
                    break;
                default:
                    break;
            }
        }

        public void Window_close(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        public void addTheBall(float x, float y)
        {
            for(int i = 0; i < 1; i++)
            {
                float velocityX = (float)(random.NextDouble() - 0.5) * speed;
                float velocityY = (float)(random.NextDouble() - 0.5) * speed;
                int randValue = random.Next(0,255);
                BlueBall ball = new BlueBall(new Color((byte)(randValue), 100, 150), Color.Blue, randValue, circleSize);

               
                ball.setPosition(x, y);
                ball.setVelocity(velocityX, velocityY);
                balls.Enqueue(ball);
            
            }
        }

        public void DrawCircles()
        {
            if (this.balls.count == 0) return;
            // for loop to create the ball links and make sure they don't draw over the balls
            
            for (Node<BlueBall> trav = this.balls.head; trav != null; trav = trav.next)
            {
                trav.data.DrawLink(window, RenderStates.Default);
            }

            for (Node<BlueBall> ahead = this.balls.head; ahead != null; ahead = ahead.next)
            {
                ahead.data.Draw(window, RenderStates.Default);
                Text valueofBall = new Text(ahead.data.displValue.ToString(), font, 25);
                valueofBall.Position = new Vector2f(ahead.data.Position.X - 10f, ahead.data.Position.Y + 25f);
                this.window.Draw(valueofBall);
            }
        }

        public void UpdateCircles()
        {
            if (this.balls.count == 0) return;

            for (Node<BlueBall> trav = this.balls.head; trav != null; trav = trav.next)
            {
                Vector2f linktarget = trav.next != null ? trav.next.data.Position : trav.data.Position;
        
                trav.data.Update(this.delta.AsSeconds(), linktarget, 0, 0, window.Size.X, window.Size.Y);
            }
        }

    }

