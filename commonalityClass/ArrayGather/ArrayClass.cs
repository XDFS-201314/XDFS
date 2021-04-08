using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 数组集合
/// </summary>
namespace commonalityClass.ArrayGather {
    public partial class ArrayClass {


        #region 数组操作
        //1.Array.FindAll(数组,o=>o.Contains(字符)):使用FindAll方法查找相应字符串
        #endregion

        #region 1.一维数组中添加元素
        /// <summary>
        /// int数组
        /// </summary>
        /// <param name="ArrayBorn">需要添加元素的一维数组</param>
        /// <param name="Index">添加索引</param>
        /// <param name="Value">添加值</param>
        /// <param name="error">返回异常</param>
        /// <returns></returns>
        public static int[] int_AddArray(int[] ArrayBorn, int Index, int Value,ref string error) {
            int[] TemArray = null;
            try {
                if (Index >= (ArrayBorn.Length)) {
                    Index = ArrayBorn.Length - 1;
                }
                TemArray = new int[ArrayBorn.Length+1];
                for (int i = 0; i < TemArray.Length; i++) {//遍历新数组的元素
                    if (Index>=0) {//判断添加索引是否大于等于0
                        if (i < (Index + 1)) {//判断遍历到索引是否小于添加索引加1
                            TemArray[i] = ArrayBorn[i];//交换元素值
                        } else if (i == (Index + 1)) {//判断遍历到的索引是否等于添加索引加1
                            TemArray[i] = Value;//为遍历到的索引设置添加值
                        } else {
                            TemArray[i] = ArrayBorn[i - 1];//交换元素值
                        }
                    } else {
                        if (i == 0)//判断遍历到的索引是否为0
                            TemArray[i] = Value;//为遍历到的索引设置添加值
                        else
                            TemArray[i] = ArrayBorn[i - 1];//交换元素值
                    }
                }
               
            } catch (Exception ex) {
                error = ex.ToString();
            }
            return TemArray;
        }
        /// <summary>
        /// string数组
        /// </summary>
        /// <param name="ArrayBorn">需要添加元素的一维数组</param>
        /// <param name="Index">添加索引</param>
        /// <param name="Value">添加值</param>
        /// <returns></returns>
        public static string[] str_AddArray(string[] ArrayBorn, int Index, string Value ,ref string error) {
            string[] TemArray = null;
            try {
                if (Index >= (ArrayBorn.Length)) {
                    Index = ArrayBorn.Length - 1;
                }
                TemArray = new string[ArrayBorn.Length + 1];
                for (int i = 0; i < TemArray.Length; i++) {//遍历新数组的元素
                    if (Index >= 0) {//判断添加索引是否大于等于0
                        if (i < (Index + 1)) {//判断遍历到索引是否小于添加索引加1
                            TemArray[i] = ArrayBorn[i];//交换元素值
                        } else if (i == (Index + 1)) {//判断遍历到的索引是否等于添加索引加1
                            TemArray[i] = Value;//为遍历到的索引设置添加值
                        } else {
                            TemArray[i] = ArrayBorn[i - 1];//交换元素值
                        }
                    } else {
                        if (i == 0)//判断遍历到的索引是否为0
                            TemArray[i] = Value;//为遍历到的索引设置添加值
                        else
                            TemArray[i] = ArrayBorn[i - 1];//交换元素值
                    }
                }

            } catch (Exception ex) {
                error = ex.ToString();
            }
            return TemArray;
        }
        #endregion

        #region 2.一维数组中添加数组
        public static int[] AddArrays(int[] ArrayBorn,int[] ArrayAdd,int Index) {
            if (Index >= (ArrayBorn.Length)) {//判断添加索引是否大于数组的长度
                Index = ArrayBorn.Length - 1;//将添加
            }
            int[] TemArray = new int[ArrayBorn.Length + ArrayAdd.Length];//声明一个新的数组
            for (int i = 0; i < TemArray.Length; i++) {//遍历新数组的元素
                if (Index >=0) {//判断添加索引是否大于等于0
                    if (i<Index+1) {//判断遍历到的索引是否小于添加索引加1
                        TemArray[i] = ArrayBorn[i];//交换元素值
                    } else if (i== (Index+1))  {
                        for (int j = 0; j < ArrayAdd.Length; j++) {
                            TemArray[i + j] = ArrayAdd[j];//为遍历的索引设置添加值
                        }
                        i = i + ArrayAdd.Length - 1;//将遍历索引设置为要添加数组的索引最大值
                    }else{
                        TemArray[i] = ArrayBorn[i - ArrayAdd.Length];//交换元素值
                    }
                } else {
                    if (i==0) {//判断遍历到的索引是否0
                        for (int j= 0; j < ArrayAdd.Length; j++) {//遍历要添加的数组
                            TemArray[i + j] = ArrayAdd[j];//为遍历到的索引设置添加值
                        }
                        i = i + ArrayAdd.Length - 1;//将遍历索引设置为要添加数组的索引最大值
                    } else {
                        TemArray[i] = ArrayBorn[i- ArrayAdd.Length];//交换元素值
                    }
                }
            }
            return TemArray;//返回添加数组后的新数组
        }
        #endregion 
    }
}


