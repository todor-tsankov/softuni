﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        private string name;

        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new InvalidProgramException("Name cannot be null!");
                }

                this.name = value;
            }
        }
    }
}
