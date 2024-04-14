using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWA.Models;

namespace TPWA.Interfaces
{
    public interface IBallRepository
    {
        List<Ball> GetBalls();
        void AddBall(Ball ball);
        void ClearBalls();
    }
}
