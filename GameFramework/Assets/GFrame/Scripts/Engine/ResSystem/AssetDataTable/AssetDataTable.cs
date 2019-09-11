﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{

    public class AssetDataTable : TSingleton<AssetDataTable>
    {
        private List<AssetDataPackage> m_ActiveAssetDataPackages = new List<AssetDataPackage>();
        private List<AssetDataPackage> m_AllAssetDataPackage = new List<AssetDataPackage>();

        public List<AssetDataPackage> allAssetDataPackage
        {
            get { return m_AllAssetDataPackage; }
        }

        #region Public Func
        public void SwitchLanguage(string key)
        {

        }

        public void Reset()
        {
            for (int i = m_AllAssetDataPackage.Count - 1; i >= 0; --i)
            {
                m_AllAssetDataPackage[i].Reset();
            }
            m_ActiveAssetDataPackages.Clear();
            m_AllAssetDataPackage.Clear();
        }

        public void Save(string path)
        {
            for (int i = 0; i < m_AllAssetDataPackage.Count; i++)
            {
                m_AllAssetDataPackage[i].Save(path);
            }
        }

        #endregion
        public int AddAssetBundle(string name, string[] depends, string md5, int fileSize, long buildTime, out AssetDataPackage package)
        {
            package = null;
            if (string.IsNullOrEmpty(name))
            {
                return -1;
            }

            string key = null;
            string path = null;
            GetPackageKeyFromABName(name, out key, out path);
            if (string.IsNullOrEmpty(key))
            {
                return -1;
            }

            package = GetAssetDataPackage(key);
            if (package == null)
            {
                package = new AssetDataPackage(key, path, DateTime.Now.Ticks);
                m_AllAssetDataPackage.Add(package);
                Log.i("#Add AssetDataPackage:" + key);
            }

            return package.AddAssetBundle(name, depends, md5, fileSize, buildTime);
        }


        private void GetPackageKeyFromABName(string name, out string key, out string path)
        {
            int index = name.IndexOf('/');
            if (index < 0)
            {
                key = name;
                path = key;
                return;
            }
            key = name.Substring(0, index);
            path = key;
            // string keyResult = null;
            // string pathResult = key;

            return;
        }

        private AssetDataPackage GetAssetDataPackage(string key)
        {
            for (int i = m_AllAssetDataPackage.Count - 1; i >= 0; --i)
            {
                if (m_AllAssetDataPackage[i].key.Equals(key))
                {
                    return m_AllAssetDataPackage[i];
                }
            }
            return null;
        }

        public ABUnit GetABUnit(string path)
        {
            ABUnit unit = null;
            for (int i = m_AllAssetDataPackage.Count - 1; i >= 0; --i)
            {
                unit = m_AllAssetDataPackage[i].GetABUnit(path);
                if (unit != null) break;
            }
            return unit;
        }
    }
}




