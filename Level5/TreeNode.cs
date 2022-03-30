using System.Collections.Generic;
using System.Linq;

namespace Level5
{
    /// <summary>式ツリーの基底クラス</summary>
    public abstract class TreeNode
    {
        public abstract double Calculate();

        private static bool IsLowPriority(Operator ope)
            => (ope?.OperateType == OperateType.Plus || ope?.OperateType == OperateType.Minus);
        private static bool IsHighPriority(Operator ope)
            => (ope?.OperateType == OperateType.Multi || ope?.OperateType == OperateType.Division);

        // 式リストから式ノードを作成する
        public static TreeNode Parse(List<Element> elements)
        {
            // 優先順位の低い演算子＞優先順位の高い演算子、の順で演算子を右から検索する
            int idx = elements.FindLastIndex(e => IsLowPriority(e as Operator));
            idx = (idx >= 0) ? idx : elements.FindLastIndex(e => IsHighPriority(e as Operator));

            if (idx < 0)
            {
                // 演算子がない時は葉になる
                Leaf result = new Leaf();
                result.Value = (elements.First() as InputNumber).Value;
                return result;
            }
            else
            {
                // 見つかった演算子で左右に分割する
                Branch result = new Branch();
                result.Operator = elements.ElementAt(idx) as Operator;
                result.Left = Parse(elements.Take(idx).ToList());
                result.Right = Parse(elements.Skip(idx + 1).ToList());
                return result;
            }
        }
    }

    /// <summary>式ツリーの枝</summary>
    public class Branch : TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public Operator Operator { get; set; }

        public override double Calculate()
            => Operator.Calculate(Left?.Calculate() ?? 0, Right?.Calculate() ?? 0);

        public override string ToString()
            => $"{Left} {Operator} {Right}";
    }

    /// <summary>式ツリーの葉</summary>
    public class Leaf : TreeNode
    {
        public double Value { get; set; }

        public override double Calculate()
            => Value;

        public override string ToString()
            => Value.ToString();
    }
}
