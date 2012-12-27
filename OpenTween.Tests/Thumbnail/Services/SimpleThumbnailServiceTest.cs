﻿// OpenTween - Client of Twitter
// Copyright (c) 2012 kim_upsilon (@kim_upsilon) <https://upsilo.net/~upsilon/>
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
using NUnit.Framework;

namespace OpenTween.Thumbnail.Services
{
    [TestFixture]
    class SimpleThumbnailServiceTest
    {
        [Test]
        public void RegexMatchTest()
        {
            var service = new SimpleThumbnailService(@"http://example.com/(.+)", @"http://img.example.com/$1");

            var thumbinfo = service.GetThumbnailInfo("http://example.com/abcd", null);

            Assert.That(thumbinfo, Is.Not.Null);
            Assert.That(thumbinfo.ImageUrl, Is.EqualTo("http://example.com/abcd"));
            Assert.That(thumbinfo.ThumbnailUrl, Is.EqualTo("http://img.example.com/abcd"));
            Assert.That(thumbinfo.TooltipText, Is.Null);
        }

        [Test]
        public void RegexNotMatchTest()
        {
            var service = new SimpleThumbnailService(@"http://example.com/(.+)", @"http://img.example.com/\1");

            var thumbinfo = service.GetThumbnailInfo("http://hogehoge.com/abcd", null);

            Assert.That(thumbinfo, Is.Null);
        }
    }
}
