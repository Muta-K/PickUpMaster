using System.Collections;
using System.Collections.Generic;
using MiniJSON; // Json

public class ItemDataModel
{

    public static List<Itemdata> DeserializeFromJson(string sStrJson)
    {
        var ret = new List<Itemdata>();

        // JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
        IList jsonList = (IList)Json.Deserialize(sStrJson);

        // リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
        foreach (IDictionary jsonOne in jsonList)
        {
            var tmp = new Itemdata();

            //該当するキー名が jsonOne に存在するか調べ、存在したら取得して変数に格納する。
            if (jsonOne.Contains("Id"))
            {
                tmp.Id = (int)(long)jsonOne["Id"];
            }

            if (jsonOne.Contains("Itemname"))
            {
                tmp.Itemname = (string)jsonOne["Itemname"];
            }

            if (jsonOne.Contains("Attack"))
            {
                tmp.Attack = (int)(long)jsonOne["Attack"];
            }

            if (jsonOne.Contains("Speed"))
            {
                tmp.Speed = (int)(long)jsonOne["Speed"];
            }

            ret.Add(tmp);
        }

        return ret;
    }
}
