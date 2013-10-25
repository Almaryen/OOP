using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sea_Battle
{
    class Playing_field
    {
        public int [,] GamePlay= new int [10,10];
        public Playing_field() //создаем пустое игровое поле
        {
            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 10; j++) 
                {
                    GamePlay[i, j] = 0;//-1;
                }
            }
        }

        public void reset() 
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.GamePlay[i, j] = 0;//-1;
                }
            }
        }

        public void arrangement()
        { 
            Random rng = new Random();
            
             for (int Power = 4; Power > 0 ; Power--)
                 for (int NumShip = 0; NumShip < 5 - Power; NumShip++)
                 {
                    bool b = false;
                    do
                    {
                        Cell c = new Cell(rng.Next(10)%100,rng.Next(10));
                        ship s= new ship(rng.Next(2),Power);
                        if (chek_fild(c,s)) 
                        {
                            Add_ship(c, s);
                            b=true;
                        }

                    }
                    while(!b);
                 }
        }
        public void Add_ship( Cell c, ship s)
        {
            //if (chek_fild(c, s))
            {
                if (s.orientation == 1)//1-верт
                {
                    for (int j = 0; j < s.power; j++)
                    {
                        this.GamePlay[c.x, c.y + j] = 1;
                    }
                }
                if (s.orientation == 0)//0-горизонт
                {
                    for (int i = 0; i < s.power; i++)
                    {
                        this.GamePlay[c.x + i, c.y] = 1;
                    }
                }
            }
            //else MessageBox.Show("Error", "Error",
            //                     MessageBoxButtons.YesNo,
            //                     MessageBoxIcon.Question);
        }

        private bool chek_fild(Cell c, ship s) 
        {
            int x, y;
  
            if (s.orientation == 0)//0-горизонт
            {
                for (int i = 0; i < s.power + 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        y = c.y - 1 + j;
                        x = c.x - 1 + i;

                        if (c.x - 1 + i == -1) x = c.x;
                        if (c.x - 1 + i > 9) return false;

                        if (y > 9) y -= 1;//прилегает к краю в рамках правил
                        if (y < 0) y += 1; //прилегает к краю в рамках правил

                        if (this.GamePlay[x, y] != 0/*-1*/)
                            return false;
                    }
                }
                return true;
            }
            if (s.orientation == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < s.power + 2; j++)
                    {
                        x =c.x - 1 + i;
                        y = c.y - 1 + j;

                        if (c.y - 1 + j == -1) y = c.y;
                        if (c.y - 1 + j > 9) return false;

                        if (x > 9) x -= 1; //прилегает к краю в рамках правил
                        if (x < 0) x += 1;  //прилегает к краю в рамках правил
                        if (c.y - 1 + j > 9) return false;
                        if (this.GamePlay[x, y]!= 0/*-1*/)
                        return false;
                    }
                }
                return true;
            }
            else
            return false;
        }
    }
    class  Cell 
    {
       public int x;
       public int y;
       public Cell(int _x, int _y) 
       {
           x = _x;
           y = _y;
       }
    }

    class ship 
    {
        public int orientation;//0-горизонт 1-верт
        public int power;// 1..4
        public ship(int _orientation, int _power)
        {
            this.orientation = _orientation;
            this.power = _power;
        }
        
    }
}
