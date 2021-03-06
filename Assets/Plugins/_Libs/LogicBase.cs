using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyEngine
{
    public class LogicBase
    {
        protected const int EMPTY = 0;
        protected const int ERROR = -1;

        private int mCheckValue = ERROR; // 현재 탐색중인 돌의 색 

        public void setCheckValue(int _newcheckvalue)
        {
            mCheckValue = _newcheckvalue;
        }

        protected bool isSequential(int _data, ref int _length)
        {
            if (_data == mCheckValue)
            {
                _length++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

