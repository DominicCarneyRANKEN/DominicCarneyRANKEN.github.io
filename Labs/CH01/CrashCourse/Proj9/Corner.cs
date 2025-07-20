using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj9
{
    public class Corner : ITurnable
    {
        public string Turn()
        {
            return "Corner - walk to edge of corner, turn 90 degrees to the left or right and continue";
        }
    }
}
