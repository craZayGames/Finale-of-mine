using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Finale_of_mine
{
    class Lock
    {        
        private Texture2D _texture,_texture2;
        private Color _colour;
        private bool _locked;
        private Rectangle _bounds;
        private int[] _locknum= new int[3];
        private Vector2 _vector=new Vector2(250,50);
        private string _code;
        public void thelock(bool b)
        {
            if (b == true)
                _locked = b;
        }
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Color Colour
        {
            get { return _colour; }
        }
        public Rectangle Bounds
        {
            get { return _bounds; }
            set{ _bounds = value; }
        }        
        public int[] Locknum
        { 
            get { return _locknum; }            
        }
        public string Code
        { get { return _code; } }
        string codewright,wright;
        public void locked(Player.Room room,MouseState ms)
        {
            ms = Mouse.GetState();
            if (room == Player.Room.Start )
            {
                Rectangle[] rect=new Rectangle[10];
                for(int x=0;x<=150;x+=50)
                    for(int y=0; y<=350;y+=50)                    
                        for(int i=0;i<10;i++)
                        { 
                            rect[i] = new Rectangle(x,y,50,50);
                            if (rect[i].Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                            {
                                codewright =codewright+ wright;
                                switch (i)
                                {
                                    case 0:
                                        wright = "1";
                                        break;
                                    case 1:
                                        wright = "2";
                                        break;
                                    case 2:
                                        wright = "3";
                                        break;
                                    case 3:
                                        wright = "4";
                                        break;
                                    case 4:
                                        wright = "5";
                                        break;
                                    case 5:
                                        wright = "6";
                                        break;
                                    case 6:
                                        wright = "7";
                                        break;
                                    case 7:
                                        wright = "8";
                                        break;
                                    case 8:
                                        wright = "9";
                                        break;
                                    default:
                                        wright = "0";
                                        break;
                                }
                            }
                        }                                
            }
        }              
        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            int i = 1;
            for (int x = 0; x <= 100; x += 50)
                for (int y = 200; y <=300; y += 50)
                {
                    _vector=new Vector2(x+18,y+5);                    
                    sb.Draw(_texture2, new Rectangle(x, y, 50, 50), Color.LightGray);
                    sb.DrawString(font, i.ToString(), _vector, Color.Black);
                    i++;
                }
            sb.Draw(_texture2,new Rectangle(0,350,50,50),Color.LightGray);
            sb.DrawString(font, "0", new Vector2(18,355), Color.Black);
            sb.Draw(_texture2,new Rectangle(50,350,100,50),Color.LightGray);
            sb.DrawString(font, "Enter",new Vector2(68,355),Color.Black);
            sb.Draw(Texture, Bounds, Colour);
            if (codewright == null)
                codewright = "___";
            sb.DrawString(font, codewright, new Vector2(200, 300), Color.Blue);
        }        
        public Lock(Texture2D texture, Color colour, Rectangle bounds,Texture2D texture2,Random r)
        {
            _texture = texture;
            _colour = colour;            
            _bounds = bounds;
            _texture2= texture2;
            _locknum[0] = r.Next(10);
            _locknum[1] = r.Next(10);
            _locknum[2]= r.Next(10);
            _code =Locknum[0].ToString()+Locknum[1]+Locknum[2];
        }
    }
}