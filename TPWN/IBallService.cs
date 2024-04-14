using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPW.Models;

namespace TPW.Interfaces
{
    public interface IBallService
    {
        void CreateRandomBalls(int count, double canvasWidth, double canvasHeight);
        List<Ball> GetAllBalls();
    }
}
