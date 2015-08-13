using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Lecutre.Models
{
    public class PeopleImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public byte[] Image { get; set; }
        public string TheirName { get; set; }

        public static byte[] ResizeImage(byte[] source, int width, int height)
        {
            var ms = new MemoryStream(source);
            var image = System.Drawing.Image.FromStream(ms);

            Image image2 = new Bitmap(image, new Size(width, height));

            var ms2 = new MemoryStream();
            image2.Save(ms2, ImageFormat.Jpeg);
            return ms2.ToArray();
        }
    }


    public class Ratings
    {
        public string critics_rating { get; set; }
        public int critics_score { get; set; }
        public string audience_rating { get; set; }
        public int audience_score { get; set; }
    }


    public class Movie
    {
        public string id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string mpaa_rating { get; set; }
        public int runtime { get; set; }
        public string critics_consensus { get; set; }
        public Ratings ratings { get; set; }
        public string synopsis { get; set; }
    }


    public class RootObject
    {
        public string Daniel { get; set; }
        public int total { get; set; }
        public List<Movie> movies { get; set; }
    }
}