﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.Facebook
{
    public class FacebookPersonAuth
    {
        public FacebookPersonAuth()
        {
            isLogined = false;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public bool isLogined { get; set; }
    }
}
