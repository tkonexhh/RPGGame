﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{

    public class GameData : IDataClass
    {
        public int s = 0;
        public GameData()
        {
            SetDirtyRecorder(PlayerInfoMgr.dataDirtyRecorder);
        }
        public override void InitWithEmptyData()
        {
            s = 10;
        }

        public override void OnDataLoadFinish()
        {

        }
    }
}




