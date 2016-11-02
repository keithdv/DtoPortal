﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortal
{
    public class DependencyPropertyInfo<T> : IDependencyPropertyInfo<T>
    {

        private string _name;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }


        public DependencyPropertyInfo(string name)
        {
            this.Name = name;
        }

    }
}
