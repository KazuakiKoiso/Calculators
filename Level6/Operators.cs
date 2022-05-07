using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level6
{
    /// <summary>計算種別</summary>
    public enum OperateType
    {
        /// <summary>未入力</summary>
        None,
        /// <summary>加算</summary>
        Plus,
        /// <summary>減算</summary>
        Minus,
        /// <summary>乗算</summary>
        Multi,
        /// <summary>除算</summary>
        Division,
    }

    /// <summary>２項演算のインターフェース</summary>
    public abstract class Operator : Element
    {
        public abstract OperateType OperateType { get; }

        public abstract double Calculate(double value1, double value2);
    }

    /// <summary>加算</summary>
    public class Plus : Operator
    {
        public override OperateType OperateType => OperateType.Plus;

        public override double Calculate(double value1, double value2)
            => value1 + value2;

        public override string ToString()
            => "＋";
    }

    /// <summary>減算</summary>
    public class Minus : Operator
    {
        public override OperateType OperateType => OperateType.Minus;

        public override double Calculate(double value1, double value2)
            => value1 - value2;

        public override string ToString()
            => "－";
    }

    /// <summary>乗算</summary>
    public class Multi : Operator
    {
        public override OperateType OperateType => OperateType.Multi;

        public override double Calculate(double value1, double value2)
            => value1 * value2;

        public override string ToString()
            => "×";
    }

    /// <summary>除算</summary>
    public class Division : Operator
    {
        public override OperateType OperateType => OperateType.Division;

        public override double Calculate(double value1, double value2)
            => value2 == 0 ? 0 : value1 / value2;

        public override string ToString()
            => "÷";
    }

    /// <summary>計算機を作成する</summary>
    public static class OperatorFactory
    {
        /// <summary>計算機を作成する</summary>
        public static Operator Create(OperateType operateType)
        {
            switch(operateType)
            {
                case OperateType.Plus:return new Plus();
                case OperateType.Minus:return new Minus();
                case OperateType.Multi:return new Multi();
                case OperateType.Division:return new Division();
            }
            return null;
        }
    }
}
