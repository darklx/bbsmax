﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MaxLabs.bbsMax.RegExp
{
	public class TemplateCodeBlockRegex : Regex
	{
		/* 原正则
{
  (?<out>=){0,1}
  (?<content>
    (?>
        (?>"[^"\\\r\n]*(?:\\.[^"\\\r\n]*)*")
        |
        (?>'[^'\\\r\n]*(?:\\.[^'\\\r\n]*)*')
        |
        (?<!\\){(?<pl>)
        |
        (?<!\\)}(?<-pl>)
        |
        [^"'{}\r\n]+
    )*
    (?(pl)(?!))
  )
}
		 */

		private const string PATTERN = @"{
  (?<out>=){0,1}
  (?<content>
    (?>
        (?>""[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*"")
        |
        (?>'[^'\\\r\n]*(?:\\.[^'\\\r\n]*)*')
        |
        (?<!\\){(?<pl>)
        |
        (?<!\\)}(?<-pl>)
        |
        [^""'{}\r\n]+
    )*
    (?(pl)(?!))
  )
}";

		private const RegexOptions OPTIONS = RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled;

		public TemplateCodeBlockRegex()
			: base(PATTERN, OPTIONS)
		{
		}
	}
}