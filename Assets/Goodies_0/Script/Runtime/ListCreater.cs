namespace Goodies_0
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class GameObjList
    {
        [SerializeField] GameObject m_prefab;
        [SerializeField] Transform containerParent;
        List<GameObject> objList;
        int objCount = 0;
        public void Create(int count_, GameObject pref_, Transform contentPan_)
        {
            if (this.objList == null)
                this.objList = new List<GameObject>(count_);
            for (int i = 0; i < count_; i++)
            {
                GameObject g = Object.Instantiate(pref_);
                g.transform.SetParent(contentPan_);
                g.transform.localScale = Vector3.one;
                this.objList.Add(g);
            }
            this.objCount = this.objList.Count;
        }
        public void SetActive(bool active_)
        {
            for (int i = 0; i < this.objCount; i++)
            {
                if (this.objList[i].activeSelf != active_)
                    this.objList[i].SetActive(active_);
            }
        }
        public static void Create<T>(int count_, GameObject pref_, Transform contentPan_,out List<T> objList) where T : Component
        {
            objList = new List<T>(count_);
            for (int i = 0; i < count_; i++)
            {
                GameObject g = Object.Instantiate(pref_);
                g.transform.SetParent(contentPan_);
                g.transform.localScale = Vector3.one;
                objList.Add(g.GetComponent<T>());
            }
        }
        public void TryClean()
        {
            if (this.objList != null)
            {
                if (this.objCount > 0)
                {
                    for (int i = 0; i < this.objCount; i++)
                    {
                        if (this.objList[i] != null)
                            Object.Destroy(this.objList[i]);
                    }
                    this.objList.Clear();
                    this.objCount = 0;
                }
            }
        }
    }

    [System.Serializable]
    public class ListCreater<T1> where T1 : Component
    {
        [SerializeField] GameObject m_prefab;
        [SerializeField] Transform containerParent;
        List<T1> objList;
        int objCount = 0;
        public void CleanAndCreat(int count_)
        {
            this.TryClean();
            this.Create(count_);
        }
        public void CleanAndCreat(int count_, GameObject pref_, Transform contentPan_)
        {
            this.TryClean();
            this.Create(count_,pref_,contentPan_);
        }
        public void Create(int count_)
        {
            this.Create(count_, this.m_prefab, this.containerParent);
        }
        public void Create(int count_,GameObject pref_,Transform contentPan_)
        {
            GameObjList.Create(count_, pref_, contentPan_, out this.objList);
            this.objCount = this.objList.Count;
        }
        public void SetActive(bool active_)
        {
            for (int i = 0; i < this.objCount; i++)
            {
                if (this.objList[i].gameObject.activeSelf != active_)
                    this.objList[i].gameObject.SetActive(active_);
            }
        }
        public void TryClean()
        {
            if (this.objList != null)
            {
                if (this.objCount > 0)
                {
                    for (int i = 0; i < this.objCount; i++)
                    {
                        if (this.objList[i] != null)                        
                           Object.Destroy(this.objList[i].gameObject);                        
                    }
                    this.objList.Clear();
                    this.objCount = 0;
                }
            }
        }
    }

}