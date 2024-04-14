using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWA.Models;

namespace TPWA.Interfaces
{
    public interface IBallService
    {
        void CreateRandomBalls(int count, double canvasWidth, double canvasHeight);
        List<Ball> GetAllBalls();
    }
}
