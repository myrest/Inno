$(function () {
    var fbGroupUrl = 'https://graph.facebook.com/v2.1/536281986502720/feed?limit=100&access_token=' + token;
    var templatepara = fbjson;
    utility.template("Default/FBGroupDataList.html", function (template) {
        $('#FBgroup').html(template.process(templatepara));
    }, "FBgroup");


});


var fbjson = {
    "data": [
    {
        "id": "536281986502720_536326666498252",
        "from": {
            "id": "813395908691308",
            "name": "Kuan Chou"
        },
        "to": {
            "data": [
          {
              "name": "Innoroot",
              "id": "536281986502720"
          }
        ]
        },
        "message": "好像很好玩的感覺~",
        "actions": [
        {
            "name": "Comment",
            "link": "https://www.facebook.com/536281986502720/posts/536326666498252"
        },
        {
            "name": "Like",
            "link": "https://www.facebook.com/536281986502720/posts/536326666498252"
        }
      ],
        "privacy": {
            "value": ""
        },
        "type": "status",
        "created_time": "2014-09-15T18:53:06+0000",
        "updated_time": "2014-09-18T03:53:08+0000",
        "likes": {
            "data": [
          {
              "id": "10152434237009412",
              "name": "Roy Tai"
          }
        ],
            "paging": {
                "cursors": {
                    "after": "MTAxNTI0MzQyMzcwMDk0MTI=",
                    "before": "MTAxNTI0MzQyMzcwMDk0MTI="
                }
            }
        },
        "comments": {
            "data": [
          {
              "id": "537335556397363",
              "from": {
                  "id": "10152434237009412",
                  "name": "Roy Tai"
              },
              "message": "funny is ok.",
              "can_remove": true,
              "created_time": "2014-09-18T03:53:08+0000",
              "like_count": 0,
              "user_likes": false
          }
        ],
            "paging": {
                "cursors": {
                    "after": "WTI5dGJXVnVkRjlqZFhKemIzSTZOVE0zTXpNMU5UVTJNemszTXpZek9qRTBNVEV3TVRJek9EZz0=",
                    "before": "WTI5dGJXVnVkRjlqZFhKemIzSTZOVE0zTXpNMU5UVTJNemszTXpZek9qRTBNVEV3TVRJek9EZz0="
                }
            }
        }
    },
    {
        "id": "536281986502720_536291253168460",
        "from": {
            "id": "10152434237009412",
            "name": "Roy Tai"
        },
        "to": {
            "data": [
          {
              "name": "Innoroot",
              "id": "536281986502720"
          }
        ]
        },
        "message": "我的貼貼樂",
        "actions": [
        {
            "name": "Comment",
            "link": "https://www.facebook.com/536281986502720/posts/536291253168460"
        },
        {
            "name": "Like",
            "link": "https://www.facebook.com/536281986502720/posts/536291253168460"
        }
      ],
        "privacy": {
            "value": ""
        },
        "type": "status",
        "created_time": "2014-09-15T16:51:03+0000",
        "updated_time": "2014-09-15T16:51:03+0000"
    }
  ],
    "paging": {
        "previous": "https://graph.facebook.com/v2.1/536281986502720/feed?limit=100&since=1411012388&__paging_token=enc_Aewdg0OHJDe25KCwDsnFq-qLh1RqWqKqaPfNhKFt7TZkzF4JFQkjMYHcwba7A8Nsg2o0Go7xdGm5WxYwNGxRHdflKLxBUA-zAh4Xx-Dxu0f0lw",
        "next": "https://graph.facebook.com/v2.1/536281986502720/feed?limit=100&until=1410799863&__paging_token=enc_AexLx_KEx7DKC8MHU6cTEjJuTorp6XNyAwjCDd5-V1CDJjIFcDqADX4oZ_cUvWYdIJ_ptfTm36m7xAD29gLMYT8DYXZ8nurVSNyE5H-Ohp941g"
    }
}

