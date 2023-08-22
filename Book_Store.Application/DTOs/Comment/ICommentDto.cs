﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.Comment
{
    public interface ICommentDto
    {
        public string Text { get; set; }

        public int Rating { get; set; }

    }
}
