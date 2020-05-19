﻿//
// Copyright 2018-2019 Sean Spicer 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

namespace Veldrid.SceneGraph
{
    public interface IView
    {
        void SetCamera(ICamera camera);
    }
    
    public abstract class View : IView
    {
        public ICamera Camera { get; private set; }

        protected View()
        {
            Camera = PerspectiveCamera.Create();;
            Camera.SetViewport(0, 0, (int)DisplaySettings.Instance.ScreenWidth, (int)DisplaySettings.Instance.ScreenHeight);
            Camera.SetView(this);
        }

        public virtual void SetCamera(ICamera newCamera)
        {
            if (null != Camera)
            {
                var viewport = Camera.Viewport;
                newCamera.SetViewport(viewport);
            }
            else
            {
                newCamera.SetViewport(0, 0, (int)DisplaySettings.Instance.ScreenWidth, (int)DisplaySettings.Instance.ScreenHeight);
            }
            
            newCamera.SetView(this);
            Camera = newCamera;
        }
    }
}