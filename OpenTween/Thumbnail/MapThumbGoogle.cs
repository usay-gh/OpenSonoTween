﻿// OpenTween - Client of Twitter
// Copyright (c) 2012      kim_upsilon (@kim_upsilon) <https://upsilo.net/~upsilon/>
// All rights reserved.
// 
// This file is part of OpenTween.
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
// 
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details. 
// 
// You should have received a copy of the GNU General Public License along
// with this program. If not, see <http://www.gnu.org/licenses/>, or write to
// the Free Software Foundation, Inc., 51 Franklin Street - Fifth Floor,
// Boston, MA 02110-1301, USA.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTween.Thumbnail
{
    class MapThumbGoogle : MapThumb
    {
        public override string CreateStaticMapUrl(double latitude, double longitude)
        {
            var width = AppendSettingDialog.Instance.MapThumbnailWidth; // この辺なんとかならんかなあ
            var height = AppendSettingDialog.Instance.MapThumbnailHeight;
            var zoom = AppendSettingDialog.Instance.MapThumbnailZoom;
            var location = latitude.ToString() + "," + longitude.ToString();

            string baseUrl;
            if (AppendSettingDialog.Instance.UseSsl)
                baseUrl = "https://maps.googleapis.com/maps/api/staticmap";
            else
                baseUrl = "http://maps.google.com/maps/api/staticmap";

            return baseUrl + "?center=" + location + "&size=" + width + "x" + height + "&zoom=" + zoom + "&markers=" + location + "&sensor=false";
        }

        public override string CreateMapLinkUrl(double latitude, double longitude)
        {
            var zoom = AppendSettingDialog.Instance.MapThumbnailZoom;
            var location = latitude.ToString() + "," + longitude.ToString();

            string baseUrl;
            if (AppendSettingDialog.Instance.UseSsl)
                baseUrl = "https://maps.google.co.jp/maps";
            else
                baseUrl = "http://maps.google.co.jp/maps";

            return baseUrl + "?ll=" + location + "&z=" + zoom + "&q=" + location;
        }
    }
}
