﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjesi.Models.entity
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string ArticlePicture { get; set; }
        [Required]
        public User Author { get; set; }
        public int AuthorId { get; set; }
    }
}
