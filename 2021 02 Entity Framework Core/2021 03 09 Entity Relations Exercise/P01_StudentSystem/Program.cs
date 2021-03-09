using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
