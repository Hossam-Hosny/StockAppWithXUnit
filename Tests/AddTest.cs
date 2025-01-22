using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AddTest
    {


        [Fact]
        public void Add() 
        {
            // Arrange 
            int a = 10; 
            int b = 20;

            int expected = 30;
            // Act 
            int result = Math12.Add(a, b);

            // Assert 
            Assert.Equal(expected, result);
        
        }
    }
}
