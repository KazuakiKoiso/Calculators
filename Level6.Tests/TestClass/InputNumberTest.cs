using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Level6.Tests.TestClass
{
    [TestClass]
    public class InputNumberTest
    {
        #region コンストラクタの引数がない場合のテスト
        // ・初期時点でValueが0となること、ToString()が"0"となること
        // ・初期化時点でIsEmptyがtrueとなること、HasPeriodがfalseとなること
        // ・（おまけ）Push(1)後にValueが1となること、ToString()が"1"となること
        #endregion

        #region  初期値あり
        // ・初期値が1.5の場合にValueが1.5となること、ToString()が"1．5"となること
        // ・初期値が-1.5の場合にValueが-1.5となること、ToString()が"ー1．5"となること
        // ・初期値が1.5の場合にPush(2)でValueが1.52となること、ToString()が"1．52"となること
        // ・初期値が1.5の場合にIsEmptyがfalseとなること、HasPeriodがtrueとなること
        // ・（おまけ）初期値が3の場合にPush(1)でValueが31となること、ToString()が"31"となること
        #endregion

        #region Push
        // ・Push(1～9)でValueが123456789となること、ToString()が"123456789"となること
        // ・Push(-1)でArgumentExceptionが発生すること
        // ・Push(10)でArgumentExceptionが発生すること
        #endregion

        #region AddPeriod
        // ・Push(1)、AddPeriod()でValueが1となること、ToString()が"1．"となること
        // ・Push()せずにAddPeriod()でValueが0.1となること、ToString()が"0．1"となること
        // ・Push(1)、AddPeriod()、AddPeriod()でFormatExceptionが発生すること
        #endregion

        #region Pop
        // ・Value=1でPop()の戻り値が1であること、Valueが0であること、ToString()が""であること
        // ・Value=1.2でPop()の戻り値が2であること、Valueが1であること、ToString()が"１．"であること
        // ・Value=1でPop()、Pop()でExceptionが発生すること
        #endregion

        #region Clear()
        // ・Value=12.34でClear()後、Valueが0であること、ToString()が""であること
        #endregion

        #region Fix
        // ・Value=1でFix()後、Valueが1であること、ToString()が"1"であること
        // ・Value="1."でFix()後、Valueが1であること、ToString()が"1．0"であること
        #endregion
    }
}
