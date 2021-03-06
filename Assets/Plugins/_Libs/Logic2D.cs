using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyEngine
{
    public abstract class Logic2D : LogicBase
    {
        private int[,] mDat;

        private int mRow, mCol;
        private const int DATASIZE = 100;
        protected int xPos, yPos;

        protected int mTurn;
        protected int mLength;



        // read only property 
        public int Length
        {
            get { return mLength; }
        }
        public int Turn
        {
            get { return mTurn; }
        }

        //public KeyValuePair<int, int>[] mPoints = new KeyValuePair<int, int>[DATASIZE];

        protected class Point
        {
            public int r, c;
        }
        protected Point[] mPoints;

        public Vector2 getmPoints(int n)
        {
            return new Vector2(mPoints[n].r, mPoints[n].c);
        }

        protected enum Direction
        {
            U,
            UR,
            R,
            DR,
            D,
            DL,
            L,
            UL
        };

        // 좌표 기준 이동
        protected int[,] mCursormove = new int[8, 2]
        {
        {0, 1 },
        {1, 1 },
        {1, 0 },
        {1, -1 },
        {0, -1 },
        {-1, -1 },
        {-1 ,0},
        {-1, 1  }
        };

        // 배열상위치 기준 이동
        protected int[,] mCursormove_arr = new int[8, 2]
        {
        {-1,0 },
        {-1,1 },
        {0,1 },
        {1,1 },
        {1,0 },
        {1,-1 },
        {0,-1 },
        {-1,-1 }
        };

        public Logic2D(int _r, int _c)
        {
            mRow = _r;
            mCol = _c;
            initData();
        }

        public abstract bool analyze(int r, int c);

        protected void initData()
        {
            mDat = new int[mRow, mCol];
            mLength = 0;
            mTurn = 1;

            mPoints = new Point[DATASIZE];
            for (int i = 0; i < mPoints.Length; i++)
                mPoints[i] = new Point();
        }

        protected bool analyzeDirection(int cv, int dir, int sr, int sc)
        {
            setCheckValue(cv);

            for (int r = sr, c = sc;
                (0 <= r && r < mRow) && (0 <= c && c < mCol);
                r += mCursormove[dir, 0], c += mCursormove[dir, 1])
            {
                // 시작지점이므로 skip
                if (r == sr && c == sc) continue;

                // 데이터 연속성 끊김
                if (!isSequential(mDat[r, c], ref mLength))
                {
                    return (mDat[r, c] == EMPTY);
                }
                else // 같은 돌 연속됨 
                {
                    int index = mLength - 1;

                    mPoints[index].r = r;
                    mPoints[index].c = c;
                }
            }
            return true;
        }

        public void nextTurn()
        {
            mTurn = 3 - mTurn;
        }



        protected void resetLength()
        {
            mLength = 0;
        }


        protected void setValue(int value, int r, int c)
        {
            mDat[r, c] = value;
        }

        public int getData(int i, int j)
        {
            return mDat[i, j];
        }

        protected void CurPos(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        protected bool isEmpty(int r, int c)
        {
            return mDat[r, c] == EMPTY;
        }

        // 가까운 정수 좌표로 수정
        public void checkpos(ref Vector2 ori)
        {
            ori.x = Mathf.RoundToInt(ori.x);
            ori.y = Mathf.RoundToInt(ori.y);
        }

        public void CurrentTurn(GameObject TurnStone, Sprite[] StoneColor)
        {

            if (mTurn == 2) // black 
            {
                TurnStone.GetComponent<SpriteRenderer>().sprite = StoneColor[0];
            }
            else // white 
            {
                TurnStone.GetComponent<SpriteRenderer>().sprite = StoneColor[1];
            }
        }
    }
}

