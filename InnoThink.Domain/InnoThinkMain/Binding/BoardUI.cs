using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace InnoThink.Domain.InnoThinkMain.Binding
{
    [DataContract]
    public class BoardUI : Board_Info
    {
        /// <summary>
        /// 使用者圖片
        /// </summary>
        [DataMember(Name = "icon")]
        public string Picture { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [DataMember(Name = "un")]
        public string UserName { get; set; }

        /// <summary>
        /// 使用者登入ID
        /// </summary>
        [DataMember(Name = "uid")]
        public string LoginId { get; set; }

        [DataMember(Name = "Date")]
        public string DateUI
        {
            get
            {
                return DateCreated.ToString("HH:mm:ss");
            }
        }
    }
}
