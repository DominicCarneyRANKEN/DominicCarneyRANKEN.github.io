using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj8
{
    public interface ICourseAction
    {
        //An interface defines the methods that a class must implement, interface methods are-
        //public and abstract by default.

        public void StartCourse();

        public void StopCourse();
    }
}
