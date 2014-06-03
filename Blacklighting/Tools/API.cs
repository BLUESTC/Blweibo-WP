using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacklighting
{
       /**
        * statusnet API，详情见下面的网址，如果没有提及，POST与GET都是可行的，参数没有提及的话可选
        * 
        * @see https://dev.twitter.com/docs/api/1.1
        * @see http://status.net/wiki/Twitter-compatible_API
        */

    class API
    {
        public const String CONSUMER_KEY = "542e73764c164bb898960c16f5ff5d78";
        public const String CONSUMER_SECRET = "e79cf868071ab74b1932f0e6dfdcf09b";
        public const String API_FORMAT = "json";
 //       public const String API_ROOT = "http://studio.scie.in/blacklighting/BLK/statusnet-1.1.1/index.php/api/";
        public const String API_ROOT = "http://localhost/statusnet/index.php/api/";
        // 以下是twitter 移植API，注意，有些没有实现
        // 详见 http://status.net/wiki/Twitter-compatible_API
        // Timeline resources
        /**
         * 返回未设置私密的用户 ( 必须有自定义的用户头像 ) 的最近20条消息，该方法不需要身份认证。 支持格式(format)：xml, json,
         * rss, atom 参数列表：无。
         */
        public const String PUBLIC_TIME_LINE_API = API_ROOT +
            "statuses/public_timeline." + API_FORMAT;

        /**
	    * Returns a collection of the most recent Tweets and retweets posted by the
	    * authenticating user and the users they follow. The home timeline is
	    * central to how most users interact with the Twitter service.
	    * 
	    * Up to 800 Tweets are obtainable on the home timeline. It is more volatile
	    * for users that follow many users or follow users who tweet
	    * frequently.</br>
	    * 
	    * Parameters： </br><strong> count (optional)</strong> </br> Specifies the
	    * number of records to retrieve. Must be less than or equal to 200.
	    * Defaults to 20. </br><strong> since_id</strong></br> (optional)Returns
	    * results with an ID greater than (that is, more recent than) the specified
	    * ID. There are limits to the number of Tweets which can be accessed
	    * through the API. If the limit of Tweets has occured since the since_id,
	    * the since_id will be forced to the oldest ID available.Example Values:
	    * 12345</br><strong> max_id </strong></br> (optional)Returns results with
	    * an ID less than (that is, older than) or equal to the specified ID.
	    * trim_user When set to either true, t or 1, each tweet returned in a
	    * timeline will include a user object including only the status authors
	    * numerical ID. Omit this parameter to receive the complete user
	    * object.Example Values: 54321 </br><strong>exclude_replies</strong></br>
	    * This parameter will prevent replies from appearing in the returned
	    * timeline. Using exclude_replies with the count parameter will mean you
	    * will receive up-to count tweets — this is because the count parameter
	    * retrieves that many tweets before filtering out retweets and
	    * replies.Example Values: true </br><strong>trim_user</strong></br>When set
	    * to either true, t or 1, each tweet returned in a timeline will include a
	    * user object including only the status authors numerical ID. Omit this
	    * parameter to receive the complete user object. Example Values: true</br>
	    * </br><strong>contributor_details</strong></br>optional This parameter
	    * enhances the contributors element of the status response to include the
	    * screen_name of the contributor. By default only the user_id of the
	    * contributor is included Example Values:
	    * true</br><strong>include_entities</strong></br>The entities node will be
	    * disincluded when set to false. Example Values: false
	    * 
	    * @see https://dev.twitter.com/docs/api/1.1/get/statuses/home_timeline
	    */
        public const String HOME_TIME_LINE_API = API_ROOT +
            "statuses/home_timeline." + API_FORMAT;

        /**
	    * 返回最近24小时内的最新的20条认证用户及其好友更新的消息。 支持格式 ( format ) ：xml, json, rss, atom
	    * 参数列表：
	    * 
	    * 　　</br><strong>since_id</strong></br>: 可选参数（微博信息ID）.
	    * 只返回ID比since_id大（比since_id时间晚的）的微博信息内容。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/friends_timeline.xml?since_id=12345
	    * 
	    * 　　</br><strong>max_id</strong></br>: 可选参数（微博信息ID）. 返回ID不大于max_id的微博信息内容。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/friends_timeline.xml?max_id=54321
	    * 
	    * 　　</br><strong>count</strong></br>: 可选参数. 每次返回的最大记录数，不能超过200，默认20.
	    * 
	    * 　　示例: http://api.twitter.com/statuses/friends_timeline.xml?count=5
	    * 
	    * 　　</br><strong>page</br><strong>: 可选参数.
	    * 返回结果的页序号。注意：有分页限制。根据用户关注对象发表的数量，通常最多返回1,000条最新微博分页内容, 默认1
	    */
        public const String FRIENDS_TIME_LINE_API = API_ROOT +
            "statuses/friends_timeline." + API_FORMAT;

        /**
	    * 显示20条最近的对用户的回复消息， ( 消息前缀为 @username )
	    * 。该API只开放给认证用户，请求其他用户的收到的回复消息列表是非法的，无论其他用户设置私密与否。 支持格式 ( format ) ：xml,
	    * json, rss, atom 参数列表：
	    * 
	    * 　　</br><strong>since_id</strong></br>. 可选参数.
	    * 返回ID比数值since_id大（比since_id时间晚的）的提到。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/mentions.xml?since_id=12345
	    * 
	    * 　　</br><strong>max_id</strong></br>. 可选参数. 返回ID不大于max_id(时间不晚于max_id)的提到。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/mentions.xml?max_id=54321
	    * 
	    * 　　</br><strong>count</strong></br>. 可选参数. 每次返回的最大记录数（即页面大小），不大于200，默认为20。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/mentions.xml?count=200
	    * 
	    * 　　</br><strong>page</strong></br>. 可选参数. 返回结果的页序号。注意：有分页限制。
	    */
        public const String MENTIONS_API = API_ROOT + "statuses/mentions." + API_FORMAT;

        public const String REPLIES_API = API_ROOT + "statuses/replies." + API_FORMAT;

        /**
	    * 返回认证用户最近24小时内最新更新的20条消息，同样，通过给定userIdOrName参数，可以用来请求其他用户的最近的消息更新。
	    * 该API可以不认证。 支持格式 ( format )：xml, json, rss, atom 参数列表：
	    * 
	    * 　　</br><strong>id</strong></br>： 可选参数. 根据指定用户UID或微博昵称来返回微博信息。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/user_timeline/12345.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>： 可选参数.
	    * 用户UID，主要是用来区分用户UID跟微博昵称一样，产生歧义的时候，特别是在微博昵称为数字导致和用户Uid发生歧义。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/user_timeline.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>：可选参数.微博昵称，主要是用来区分用户UID跟微博昵称一样，
	    * 产生歧义的时候。
	    * 
	    * 　　示例:
	    * http://api.twitter.com/statuses/user_timeline.xml?screen_name=101010
	    * 
	    * 　　</br><strong>since_id</strong></br>：可选参数（微博信息ID）.
	    * 只返回ID比since_id大（比since_id时间晚的）的微博信息内容
	    * 
	    * 　　示例: http://api.twitter.com/statuses/user_timeline.xml?since_id=12345
	    * 
	    * 　　</br><strong>max_id</strong></br>: 可选参数（微博信息ID）. 返回ID不大于max_id的微博信息内容。
	    * 
	    * 　　示例: Example:
	    * http://api.twitter.com/statuses/user_timeline.xml?max_id=54321
	    * 
	    * 　　</br><strong>count</strong></br>: 可选参数. 每次返回的最大记录数，最多返回200条，默认20。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/user_timeline.xml?count=200
	    * 
	    * 　　</br><strong>page</strong></br>： 可选参数. 分页返回。注意：最多返回200条分页内容。
	    */
        public const String USER_TIMELINE_API = API_ROOT +
            "statuses/user_timeline." + API_FORMAT;

        /**
	    * 该API在statsnet中没有实现
	    * 
	    * @deprecated
	    */
        public const String RETWEETED_TO_ME_API = API_ROOT + "statuses/retweeted_to_me." + API_FORMAT;
        
        /**
	    * 该API在statsnet中没有实现
	    * 
	    * @deprecated
	    */
        public const String RETWEETED_BY_ME_API = API_ROOT + "statuses/retweeted_by_me." + API_FORMAT;

        /**
	    * Returns the most recent tweets authored by the authenticating user that
	    * have been retweeted by others. This timeline is a subset of the user's
	    * GET statuses/user_timeline.
	    * 
	    * </br><strong>Parameters</strong></br>Specifies the number of records to
	    * retrieve. Must be less than or equal to 100. If omitted, 20 will be
	    * assumed.
	    * 
	    * Example Values: 5</br> </br><strong>count</strong></br>Returns results
	    * with an ID greater than (that is, more recent than) the specified ID.
	    * There are limits to the number of Tweets which can be accessed through
	    * the API. If the limit of Tweets has occured since the since_id, the
	    * since_id will be forced to the oldest ID available.
	    * 
	    * Example Values: 12345</br> </br><strong>since_id</strong></br>Returns
	    * results with an ID less than (that is, older than) or equal to the
	    * specified ID.
	    * 
	    * Example Values: 54321</br> </br><strong>max_id</strong></br>Returns
	    * results with an ID less than (that is, older than) or equal to the
	    * specified ID.
	    * 
	    * Example Values: 54321</br> </br><strong>trim_user</strong></br>When set
	    * to either true, t or 1, each tweet returned in a timeline will include a
	    * user object including only the status authors numerical ID. Omit this
	    * parameter to receive the complete user object.
	    * 
	    * Example Values: true</br> </br><strong>include_entities</strong></br>The
	    * tweet entities node will be disincluded when set to false.
	    * 
	    * Example Values: false</br> </br><strong>include_entities</strong></br>The
	    * user entities node will be disincluded when set to false.
	    * 
	    * Example Values: false</br>
	    * 
	    * @see https://dev.twitter.com/docs/api/1.1/get/statuses/retweets_of_me
	    */
        public const String RETWEETS_OF_ME_API = API_ROOT + "statuses/retweeted_of_me." + API_FORMAT;

        // Status resources
        // 用户消息相关方法
        /**
         * 返回指定Id的一条消息，返回信息中包含作者信息。 支持格式 ( format ) ：xml, json 参数列表:
         * 
         * 　　</br><strong>id</strong></br>. 必须参数(微博信息ID)，要获取已发表的微博ID,如ID不存在返回空
         * 
         * 　　示例: http://api.twitter.com/statuses/show/142277.xml
         */
        public const String SHOW_API = API_ROOT + "statuses/show." + API_FORMAT;

        /**
	    * 更新认证用户的消息，必须包含content参数，且必须以POST方式请求。 成功时按指定格式返回当前的消息。 支持格式 ( format
	    * )：xml, json 参数列表:
	    * 
	    * 　　</br><strong>status</strong></br>. 必填参数，
	    * 要更新的微博信息。必须做URLEncode,信息内容部超过140个汉字,为空返回400错误。
	    * 
	    * 　　</br><strong>in_reply_to_status_id</strong></br>. 可选参数，@ 需要回复的微博信息ID,
	    * 这个参数只有在微博内容以 @username 开头才有意义。
	    * 
	    * 　　</br><strong>lat</strong></br>. 可选参数，纬度，发表当前微博所在的地理位置，有效范围 -90.0到+90.0,
	    * +表示北纬。只有用户设置中geo_enabled=true时候地理位置才有效。
	    * 
	    * 　　</br><strong>long</strong></br>. 可选参数，经度。有效范围-180.0到+180.0, +表示东经。
	    */
        public const String UPDATE_API = API_ROOT + "statuses/update." + API_FORMAT;

        /**
	    * 根据指定的id删除一条消息，认证用户必须是消息的作者。 支持格式 ( format ) ：xml, json 参数列表:
	    * 
	    * 　　</br><strong>id</strong></br> 必须，待删除的消息Id， 例如：
	    * 
	    * 　　http://api.twitter.com/statuses/destroy/12345.json
	    * 
	    * 　　或者
	    * 
	    * 　　http://api.twitter.com/statuses/destroy.xml?id=23456
	    */
        public const String DESTROY_API = API_ROOT + "statuses/destroy." + API_FORMAT;
        public const String RETWEET_API = API_ROOT + "statuses/retweet." + API_FORMAT;

        // User resources
        // 用户操作接口
        /**
         * 返回认证用户的朋友列表，内含每个用户的当前微博信息。这个方法同样可以用来请求其他用户的朋友列表，通过下面指明的方法传递id参数。 支持格式 (
         * format )：xml, json 参数列表:
         * 
         * 　　</br><strong>id</strong></br>. 选填参数. 要获取的 UID或微博昵称
         * 
         * 　　示例: http://api.twitter.com/statuses/friends/12345.json
         * 
         * 　　http://api.twitter.com/statuses/friends/12345.xml
         * 
         * 　　</br><strong>user_id</strong></br>. 选填参数. 要获取的UID
         * 
         * 　　示例: http://api.twitter.com/statuses/friends.xml?user_id=1401881
         * 
         * 　　</br><strong>screen_name</strong></br>. 选填参数. 要获取的微博昵称
         * 
         * 　　示例: http://api.twitter.com/statuses/friends.xml?screen_name=101010
         * 
         * 　　</br><strong>cursor</strong></br>. 选填参数.
         * 单页只能包含100个关注列表，为了获取更多则cursor默认从-1开始，通过增加或减少cursor来获取更多,
         * 如果没有下一页，则next_cursor返回0
         * 
         * 　　的关注列表
         * 
         * 　　示例: http://api.twitter.com/statuses/friends/williamlong.xml?cursor=-1
         * 
         * 　　示例: http://api.twitter.com/statuses/friends/williamlong.xml?cursor=
         * 1300794057949944903
         * 
         * 　　</br><strong>count</strong></br>. 可选参数.
         * 每次返回的最大记录数（即页面大小），不大于200,默认返回20。
         * 
         * 　　示例: http://api.twitter.com/statuses/friends/bob.xml?&count=200
         */
        public const String FRIENDS_API = API_ROOT + "statuses/friends." + API_FORMAT;

        /**
	    * 返回认证用户的订阅者，内含每个订阅者的当前消息。与friends一样，只需要把friends地址中的friends替换为followers即可，
	    * 其余一切包括参数都不需要改变，都是一样的用法。 支持格式 ( format )：xml, json 参数列表:
	    * 
	    * 　　</br><strong>id</strong></br>. 选填参数. 要获取粉丝的 UID或微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/statuses/followers/12345.json or
	    * http://api.twitter.com/statuses/followers/bob.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>. 选填参数. 要获取的UID
	    * 
	    * 　　示例: http://api.twitter.com/statuses/followers.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>. 选填参数. 要获取的微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/statuses/followers.xml?screen_name=101010
	    * 
	    * 　　</br><strong>cursor</strong></br>. 选填参数.
	    * 单页只能包含100个粉丝列表，为了获取更多则cursor默认从-1开始，通过增加或减少cursor来获取更多的，如果没有下一页
	    * ，则next_cursor返回0
	    * 
	    * 　　粉丝列表 示例:
	    * http://api.twitter.com/statuses/followers/barackobama.xml?cursor=-1 示例:
	    * http://api.twitter.com/statuses/followers/barackobama.xml?cursor=
	    * 1300794057949944903
	    * 
	    * 　　</br><strong>count</strong></br>. 可选参数.
	    * 每次返回的最大记录数（即页面大小），不大于200,默认返回20。
	    * 
	    * 　　示例: http://api.twitter.com/statuses/followers/bob.xml?&count=200
	    */
        public const String FOLLOWERS_API = API_ROOT + "statuses/followers." + API_FORMAT;

        /**
	    * 显示指定用户的扩展信息，需要给定用户的id或显示名称。扩展信息包括用户的页面设置、微博次数等，
	    * 因此第三方应用的开发者可以根据这些信息为用户提供合适的主题。
	    * 
	    * 　　注意：本API调用请求必须发自合法微博用户，不论请求自己/他人的扩展信息。 支持格式 ( format )：xml, json 参数列表：
	    * 
	    * 　　</br><strong>id</strong></br>. 用户UID或微博昵称。
	    * 
	    * 　　示例: http://api.twitter.com/users/show/12345.json 或
	    * http://api.twitter.com/users/show/bob.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>.
	    * 指定用户UID,主要是用来区分用户UID跟微博昵称一样，产生歧义的时候，特别是在用户账号为数字导致和用户Uid发生歧义。
	    * 
	    * 　　示例: http://api.twitter.com/users/show.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>.
	    * 指定微博昵称，主要是用来区分用户UID跟微博昵称一样，产生歧义的时候。
	    * 
	    * 　　示例: http://api.twitter.com/users/show.xml?screen_name=101010
	    */
        public const String USERS_SHOW_API = API_ROOT + "users/show." + API_FORMAT;

        // Direct message resources
        // 私信操作方法
        /**
         * 返回用户的消息列表 支持格式 ( format ) ：xml, json, rss, atom 参数列表:
         * 
         * 　　</br><strong>since_id</strong></br>. 可选参数.
         * 返回ID比数值since_id大（比since_id时间晚的）的私信。
         * 
         * 　　示例: http://api.twitter.com/direct_messages.xml?since_id=12345
         * 
         * 　　</br><strong>max_id</strong></br>. 可选参数. 返回ID不大于max_id(时间不晚于max_id)的私信。
         * 
         * 　　示例: http://api.twitter.com/direct_messages.xml?max_id=54321
         * 
         * 　　</br><strong>count</strong></br>. 可选参数. 每次返回的最大记录数（即页面大小），不大于200。
         * 
         * 　　示例: http://api.twitter.com/direct_messages.xml?count=200
         * 
         * 　　</br><strong>page</strong></br>. 可选参数. 返回结果的页序号。注意：有分页限制。
         * 
         * 　　示例: http://api.twitter.com/direct_messages.xml?page=3
         */
        public const String DIRECT_MESSAGES_API = API_ROOT + "direct_messages." + API_FORMAT;

        /**
	    * 返回用户的已发送消息列表 支持格式 ( format ) ：xml, json, rss, atom 参数列表:
	    * 
	    * 　　</br><strong>since_id</strong></br>. 可选参数.
	    * 返回ID比数值since_id大（比since_id时间晚的）的私信。
	    * 
	    * 　　示例: http://api.twitter.com/direct_messages.xml?since_id=12345
	    * 
	    * 　　</br><strong>max_id</strong></br>. 可选参数. 返回ID不大于max_id(时间不晚于max_id)的私信。
	    * 
	    * 　　示例: http://api.twitter.com/direct_messages.xml?max_id=54321
	    * 
	    * 　　</br><strong>count</strong></br>. 可选参数. 每次返回的最大记录数（即页面大小），不大于200。
	    * 
	    * 　　示例: http://api.twitter.com/direct_messages.xml?count=200
	    * 
	    * 　　</br><strong>page</strong></br>. 可选参数. 返回结果的页序号。注意：有分页限制。
	    */
        public const String DIRECT_MESSAGES_SENT_API = API_ROOT + "direct_messages/sent." + API_FORMAT;

        /**
	    * 以认证用户的身份向指定的其他用户发送一条有向消息，必须包含参数user和text,请求必须使用POST方式提交。
	    * 成功将返回完整的发送消息必须包含参数user和text，必须使用POST方式提交。成功将返回完整的发送消息。
	    * 
	    * 支持格式 ( format ) ：xml, json 参数列表：
	    * 
	    * 　　</br><strong>user: user_id或者screen_name</strong></br>
	    * 
	    * 　　</br><strong>text</strong></br>: 必须参数.
	    * 要发生的消息内容，需要做URLEncode，文本大小必须小于300个汉字
	    */
        public const String DIRECT_MESSAGES_NEW_API = API_ROOT
            + "direct_messages/new." + API_FORMAT;

        /**
         * @deprecated 该API在statusnet中没有实现！
         * 
         *             通过给定的消息id，删除指定的有向消息，认证用户只能删除其作为接受者收到的消息。使用POST和GET方法都可以 支持格式
         *             ( format ) ：xml, json 参数列表：
         * 
         *             　　</br><strong>id</strong></br>. 必填参数，要删除的私信主键ID.
         * 
         *             　　示例:
         *             http://api.twitter.com/direct_messages/destroy/12345.json
         */
        public const String DIRECT_MESSAGES_DESTROY_API = API_ROOT
			+ "direct_messages/destroy." + API_FORMAT;


	    // Friendships resources
	    // 好友关系操作方法
	    /**
	    * 创建认证用户与给定的id参数指定的用户之间的好友关系；该操作执行成功时返回被加为好友的用户信息，执行失败则返回失败的状态字串。
	    * 
	    * 支持格式 ( format ) ：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　下面的参数必须有其中一个:
	    * 
	    * 　　</br><strong>id</strong></br>. 必填参数. 要关注的用户UID或微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/friendships/create/12345.json or
	    * http://api.twitter.com/friendships/create/bob.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>. 必填参数.
	    * 要关注的用户UID,主要是用在区分用户UID跟微博昵称一样，产生歧义的时候。
	    * 
	    * 　　示例: http://api.twitter.com/friendships/create.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>.必填参数.
	    * 要关注的微博昵称,主要是用在区分用户UID跟微博昵称一样，产生歧义的时候。
	    * 
	    * 　　示例: http://api.twitter.com/friendships/create.xml?screen_name=101010
	    * 
	    * 　　</br><strong>follow</strong></br>. 可选参数。暂不支持。
	    */
	    public const String FRIENDSHIPS_CREATE_API = API_ROOT
			+ "friendships/create." + API_FORMAT;

	    /**
	    * 用来注销同指定id的用户的好友关系，当操作成功时，将返回被取消好友关系的用户，当失败时，将会返回失败信息。
	    * 
	    * 　　访问地址：http://api.twitter.com/friendships/destroy/id.format
	    * 
	    * 　　支持格式 ( format ) ：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　下面的参数必须有其中一个:
	    * 
	    * 　　</br><strong>id</strong></br>. 必填参数. 要取消关注的用户UID或微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/friendships/destroy/12345.json or
	    * http://api.twitter.com/friendships/destroy/bob.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>. 必填参数.
	    * 要取消关注的用户UID,主要是用在区分用户UID跟微博昵称一样，产生歧义的时候。
	    * 
	    * 　　示例: http://api.twitter.com/friendships/destroy.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>. 必填参数.
	    * 要取消的微博昵称,主要是用在区分用户UID跟微博昵称一样，产生歧义的时候。
	    * 
	    * 　　示例: http://api.twitter.com/friendships/destroy.xml?screen_name=101010
	    */
	    public const String FRIENDSHIPS_DESTROY_API = API_ROOT
			+ "friendships/destroy." + API_FORMAT;

	    /**
	    * 用来检验两个用户的关系是否是朋友关系或者跟随与被跟随的关系。返回相互跟随的关系结果。比如：A跟随了B。B没有跟随A。将返回对应的格式数据：如xml
	    * ，<result><AFollowB>true</AFollowB><BFollowA>false</BFollowA></result>
	    * 
	    * 　　访问地址： http://api.twitter.com/friendships/exists.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　</br><strong>user_a</strong></br>. 必填参数，要判断的用户UID
	    * 
	    * 　　</br><strong>user_b</strong></br>. 必填参数，要判断的被关注人用户UID
	    */
	    public const String FRIENDSHIPS_EXISTS_API = API_ROOT
			+ "friendships/create." + API_FORMAT;

	    /**
	    * 返回两个用户关系的详细情况
	    * 
	    * 　　访问地址： http://api.twitter.com/friendships/show.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　以下参数可不填写，如不填，则取当前用户
	    * 
	    * 　　</br><strong>source_id</strong></br>. 源用户UID
	    * 
	    * 　　示例: http://api.twitter.com/friendships/show.xml?source_id=10502
	    * 
	    * 　　</br><strong>source_screen_name</strong></br>. 源微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/friendships/show.xml?source_screen_name=bob
	    * 
	    * 　　下面参数必须选填一个:
	    * 
	    * 　　</br><strong>target_id</strong></br>. 要判断的目的用户UID
	    * 
	    * 　　示例: http://api.twitter.com/friendships/show.xml?target_id=10503
	    * 
	    * 　　</br><strong>target_screen_name</strong></br>. 要判断的目的微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/friendships/show.xml?target_screen_name=
	    * williamlong
	    */
	    public const String FRIENDSHIPS_SHOW_API = API_ROOT
			+ "friendships/show." + API_FORMAT;

	    // Friends and followers resources
	    // 获取用户列表方法
	    /**
	    * 用来获取指定的用户的朋友用户id。即自己跟随的人的id
	    * 
	    * 　　访问地址：http://api.twitter.com/friends/ids.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　</br><strong>id</strong></br>. 选填参数. 要获取好友的UID或微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/friends/ids/12345.xml or
	    * http://api.twitter.com/statuses/friends/bob.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>. 选填参数. 要获取的UID
	    * 
	    * 　　示例: http://api.twitter.com/friends/ids.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>. 选填参数. 要获取的微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/friends/ids.xml?screen_name=101010
	    * 
	    * 　　</br><strong>cursor</strong></br>. 选填参数.
	    * 单页只能包含5000个id，为了获取更多则cursor默认从-1开始，通过增加或减少cursor来获取更多的关注列表
	    * 
	    * 　　示例: http://api.twitter.com/friends/ids.xml?cursor=-1 示例:
	    * http://api.twitter.com/friends/ids.xml?cursor=1300794057949944903
	    * 
	    * 　　</br><strong>count</strong></br>. 可选参数.
	    * 每次返回的最大记录数（即页面大小），不大于5000，默认返回500。
	    * 
	    * 　　示例: http://api.twitter.com/friends/ids.xml?count=200
	    */
	    public const String FRIENDS_IDS_SHOW_API = API_ROOT + "friends/ids."
			+ API_FORMAT;

	    /**
	    * 用来获取指定的用户被跟随的用户id。
	    * 
	    * 　　访问地址：http://api.twitter.com/followers/ids.format
	    * 
	    * 　　支持格式：xml,json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　</br><strong>id</strong></br>. 选填参数. 要获取好友的UID或微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/followers/ids/12345.xml or
	    * http://api.twitter.com/statuses/friends/bob.xml
	    * 
	    * 　　</br><strong>user_id</strong></br>. 选填参数，要获取的UID
	    * 
	    * 　　示例: http://api.twitter.com/followers/ids.xml?user_id=1401881
	    * 
	    * 　　</br><strong>screen_name</strong></br>. 选填参数，要获取的微博昵称
	    * 
	    * 　　示例: http://api.twitter.com/followers/ids.xml?screen_name=101010
	    * 
	    * 　　</br><strong>cursor</strong></br>. 选填参数.
	    * 单页只能包含5000个id，为了获取更多则cursor默认从-1开始，通过增加或减少cursor来获取更多的关注列表
	    * 
	    *     示例: http://api.twitter.com/followers/ids.xml?cursor=-1
	    * 
	    * 　　示例: http://api.twitter.com/followers/ids.xml?cursor=1300794057949944903
	    * 
	    * 　　</br><strong>count</strong></br>. 可选参数.
	    * 每次返回的最大记录数（即页面大小），不大于5000，默认返回500。
	    * 
	    * 　　示例: http://api.twitter.com/followers/ids.xml?count=200
	    */
	    public const String FOLLOWERS_IDS_SHOW_API = API_ROOT
			+ "followers/ids." + API_FORMAT;

	    // Account resources
	    // 用户帐号方法
	    /**
	    * 如果用户身份验证成功则返回 http状态为 200；如果是不则返回401的状态和错误信息。此方法用了判断用户身份是否合法。
	    * 
	    * 　　访问地址：http://api.twitter.com/account/verify_credentials.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    */
	    public const String ACCOUNT_VERIFY_CREDENTIALS_SHOW_API = API_ROOT
			+ "account/verify_credentials." + API_FORMAT;

	    /**
	    * @deprecated
	    */
	    public const String ACCOUNT_END_SESSION_API = API_ROOT
			+ "account/end_session." + API_FORMAT;

	    public const String ACCOUNT_UPDATE_LOCATION_API = API_ROOT
			+ "account/update_location." + API_FORMAT;

        /**
	    * @deprecated
	    */
	    public const String ACCOUNT_UPDATE_DELIVERY_DEVICE_API = API_ROOT
			+ "account/update_delivery_device." + API_FORMAT;
	    public const String ACCOUNT_RATE_LIMIT_STATUS_API = API_ROOT
			+ "account/rate_limit_status." + API_FORMAT;

	    /**
	    * 自定义微博页面的参数。只会修改参数更新项。
	    * 
	    * 　　访问地址：http://api.twitter.com/account/update_profile.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　必须有一下参数中的一个或多个，参数值为字符串. 进一步的限制，请参阅下面的各个参数描述.
	    * 
	    * 　　</br><strong>name</strong></br>. 昵称，可选参数.不超过20个汉字
	    * 
	    * 　　</br><strong>gender</strong></br> 性别，可选参数. m,男，f,女。
	    * 
	    * 　　</br><strong>province</strong></br> 可选参数. 参考省份城市编码表
	    * 
	    * 　　</br><strong>city</strong></br> 可选参数. 参考省份城市编码表,1000为不限
	    * 
	    * 　　</br><strong>description</strong></br>. 可选参数. 不超过160个汉字.
	    */
	    public const String ACCOUNT_UPDATE_PROFILE_BACKGROUND_IMAGE_API = API_ROOT
			+ "account/update_profile_background_image." + API_FORMAT;

	    public const String ACCOUNT_UPDATE_PROFILE_IMAGE_API = API_ROOT
			+ "account/update_profile_image." + API_FORMAT;

	    // Favorite resources
	    // 收藏相关方法
	    /**
	    * 返回授权用户的最新的20条收藏的状态信息。也可以通过id或者用户名来指定一个用户，查询他最新的20条收藏的状态信息。
	    * 
	    * 　　访问地址：http://api.twitter.com/favorites.format
	    * 
	    * 　　支持格式：xml, json, rss, atom
	    * 
	    * 　　参数列表：
	    * 
	    * 　　</br><strong>page</strong></br>： 可选参数. 返回结果的页序号。注意：有分页限制。
	    * 
	    * 　　示例: http://api.twitter.com/favorites/11075.xml?page=3
	    */
	    public const String FAVORITES_API = API_ROOT + "favorites."
			+ API_FORMAT;

	    /**
	    * 收藏一条状态信息POST提交
	    * 
	    * 　　访问地址：
	    * 
	    * 　　http://api.twitter.com/favorites/create.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　</br><strong>id</strong></br> 必须，授权用户要收藏的状态信息id。
	    */
	    public const String FAVORITES_CREATE_API = API_ROOT
			+ "favorites/create." + API_FORMAT;


	    /**
	    * 删除授权用户收藏的一条状态信息
	    * 
	    * 　　访问地址：http://api.twitter.com/favorites/destroy/id.format
	    * 
	    * 　　支持格式：xml, json
	    * 
	    * 　　参数列表：
	    * 
	    * 　　</br><strong>id</strong></br> 授权用户收藏的状态信息id。
	    */
	    public const String FAVORITES_DESTROY_API = API_ROOT
			+ "favorites/destroy." + API_FORMAT;

	    // Notification resources
	    /**
	    * @deprecated
	    */
	    public const String NOTIFICATIONS_FOLLOW_API = API_ROOT
			+ "notifications/follow." + API_FORMAT;

	    /**
	    * @deprecated
	    */
	    public const String NOTIFICATIONS_LEAVE_API = API_ROOT
			+ "notifications/leave." + API_FORMAT;

	    // Block resources
	    public const String BLOCKS_CREATE_API = API_ROOT + "blocks/create."
			+ API_FORMAT;
	    public const String BLOCKS_DESTROY_API = API_ROOT
			+ "blocks/destroy." + API_FORMAT;

    	/**
	    * @deprecated
	    */
	    public const String BLOCKS_EXISTS_API = API_ROOT + "blocks/destroy."
			+ API_FORMAT;

	    /**
	    * @deprecated
	    */
	    public const String BLOCKS_BLOCKING_API = API_ROOT
			+ "blocks/blocking." + API_FORMAT;

	    // OAuth resources
	    /**
	    * Allows a Consumer application to obtain an OAuth Request Token to request
	    * user authorization. This method fulfills Section 6.1 of the OAuth 1.0
	    * authentication flow.
	    * 
	    * It is strongly recommended you use HTTPS for all OAuth authorization
	    * steps.
	    * 
	    * Usage Note: Only ASCII values are accepted for the oauth_nonce
	    * 
	    * </br><strong>Parameters</strong></br></br>
	    * </br><strong>oauth_callback</strong></br>required For OAuth 1.0a
	    * compliance this parameter is required. The value you specify here will be
	    * used as the URL a user is redirected to should they approve your
	    * application's access to their account. Set this to oob for out-of-band
	    * pin mode. This is also how you specify custom callbacks for use in
	    * desktop/mobile applications.
	    * 
	    * Always send an oauth_callback on this step, regardless of a
	    * pre-registered callback.
	    * 
	    * Example Values: http%3A%2F%2Fthemattharris.local%2Fauth.php,
	    * twitterclient%3A%2F%2Fcallback</br>
	    * 
	    * </br><strong>x_auth_access_type</strong></br>optional Overrides the
	    * access level an application requests to a users account. Supported values
	    * are read or write. This parameter is intended to allow a developer to
	    * register a read/write application but also request read only access when
	    * appropriate.</br>
	    * 
	    * </br><strong>Example Request</strong></br> Request URL: POST
	    * https://api.twitter.com/oauth/request_token
	    * 
	    * Request POST Body: N/A
	    * 
	    * Authorization Header: OAuth
	    * oauth_nonce="K7ny27JTpKVsTgdyLdDfmQQWVLERj2zAK5BslRsqyw", oauth_callback=
	    * "http%3A%2F%2Fmyapp.com%3A3005%2Ftwitter%2Fprocess_callback",
	    * oauth_signature_method="HMAC-SHA1", oauth_timestamp="1300228849",
	    * oauth_consumer_key="OqEqJeafRSF11jBMStrZz",
	    * oauth_signature="Pc%2BMLdv028fxCErFyi8KXFM%2BddU%3D", oauth_version="1.0"
	    * 
	    * Response: oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik&
	    * oauth_token_secret
	    * =Kd75W4OQfb2oJTV0vzGzeXftVAwgMnEK9MumzYcM&oauth_callback_confirm
	    */
	    public const String OAUTH_REQUEST_TOKEN_API = API_ROOT
			+ "oauth/request_token";

	    /**
	    * Allows a Consumer application to use an OAuth Request Token to request
	    * user authorization. This method fulfills Section 6.2 of the OAuth 1.0
	    * authentication flow. Desktop applications must use this method (and
	    * cannot use GET oauth/authenticate).
	    * 
	    * Please use HTTPS for this method, and all other OAuth token negotiation
	    * steps.
	    * 
	    * Usage Note: An oauth_callback is never sent to this method, provide it to
	    * POST oauth/request_token instead.
	    * 
	    * </br><strong>Parameters</strong></br>
	    * </br><strong>force_login</strong></br>Forces the user to enter their
	    * credentials to ensure the correct users account is authorized.</br>
	    * </br><strong>screen_name</strong></br>Prefills the username input box of
	    * the OAuth login screen with the given value.</br> </br><strong>Example
	    * Request</strong></br> Send the user to the oauth/authorize step in a web
	    * browser, including an oauth_token parameter:
	    * https://api.twitter.com/oauth
	    * /authorize?oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik
	    */
	    public const String OAUTH_AUTHORIZE_API = API_ROOT
			+ "oauth/authorize";

	    /**
	    * Allows a Consumer application to exchange the OAuth Request Token for an
	    * OAuth Access Token. This method fulfills Section 6.3 of the OAuth 1.0
	    * authentication flow.
	    * 
	    * The OAuth access token may also be used for xAuth operations.
	    * 
	    * Please use HTTPS for this method, and all other OAuth token negotiation
	    * steps.
	    * 
	    * </br><strong>Parameters</strong></br>
	    * </br><strong>x_auth_password</strong></br>The password of the user for
	    * which to obtain a token for. Required when using xAuth
	    * </br><strong>x_auth_username</strong></br>The username of the user to
	    * obtain a token for. Required when using xAuth
	    * </br><strong>x_auth_mode</strong></br>Set this value to client_auth,
	    * without the quotes. Required when using xAuth
	    * </br><strong>oauth_verifier</strong></br>If using the OAuth web-flow, set
	    * this parameter to the value of the oauth_verifier returned in the
	    * callback URL. If you are using out-of-band OAuth, set this value to the
	    * pin-code. When using xAuth, this value should not be included.
	    * 
	    * For OAuth 1.0a compliance this parameter is required unless you are using
	    * xAuth. Currently Twitter supports both OAuth 1.0 and OAuth 1.0a which
	    * means we do not error if this value isn't included. OAuth 1.0a is now
	    * strictly enforced and applications not using the oauth_verifier will fail
	    * to complete the OAuth flow. If you're not receiving an oauth_verifier in
	    * your callback, verify that you're explicitly setting your oauth_callback
	    * on POST oauth/request_token.
	    * 
	    * </br><strong>Example Request</strong></br> Response to a successful
	    * request
	    * 
	    * oauth_token=6253282-eWudHldSbIaelX7swmsiHImEL4KinwaGloHANdrY&
	    * oauth_token_secret=
	    * 2EEfA6BG3ly3sR3RjE0IBSnlQu4ZrUzPiYKmrkVU&user_id=6253282&screen_name=twitte
	    * r a
	    */
	    public const String OAUTH_ACCESS_TOKEN_API = API_ROOT
			+ "oauth/authorize";

	    // 以下是statusnet 私有API
	    /**
	    * GET Shows a group's timeline. Similar to other timeline resources
	    * params:page (int), count (int), max_id (int), since_id (int), format
	    * (string, 'xml', 'json', 'atom', or 'rss'), callback (string, JSON-P
	    *  callback) [format is required]
	    */
	    public const String GROUPS_TMELINE_API = API_ROOT
			+ "statusnet/groups/timeline." + API_FORMAT;
	    
        /**
	    * GET Show a groups profile. params: id (string, group ID or nickname),
	    * group_id (int), group_name (string), format (string, 'xml' or 'json'),
	    * callback (string, JSON-P callback) [format is required; must also include
	    * a param identifying a group]
	    */
	    public const String GROUPS_SHOW_API = API_ROOT
			+ "statusnet/groups/show." + API_FORMAT;

	    /**
	    * POST Create a new group. params: nickname (string, name of the group),
	    * full_name (string), homepage (string), description (string), location
	    * (string), aliases (string, comma-separated), format (string, 'xml' or
	    * 'json'), callback (string, JSON-P callback function) [format and nickname
	    * are required]
	    */
	    public const String GROUPS_CREATE_API = API_ROOT
			+ "statusnet/groups/create." + API_FORMAT;

	    /**
	    * POST Join a group. params: id (string, group ID or nickname), group_id
	    * (int), group_name (string), format (string, 'xml' or 'json'), callback
	    * (string, JSON-P callback) [format is required; must also include a param
	    * identifying a group]
	    */
	    public const String GROUPS_JOIN_API = API_ROOT
			+ "statusnet/groups/join." + API_FORMAT;

	    /**
	    * POST leave a group. params: id (string, group ID or nickname), group_id
	    * (int), group_name (string), format (string, 'xml' or 'json'), callback
	    * (string, JSON-P callback) [format is required; must also include a param
	    * identifying a group]
	    */
	    public const String GROUPS_LEAVE_API = API_ROOT
			+ "statusnet/groups/leave." + API_FORMAT;

	    /**
	    * GET Show the groups a given user is a member of. params: id (string, user
	    * ID or nickname), user_id (int), screen_name (string), format (string,
	    * 'xml' or 'json'), callback (string, JSON-P callback) [format is required;
	    * must also include a param identifying a user]
	    */
	    public const String GROUPS_LIST_API = API_ROOT
			+ "statusnet/groups/list." + API_FORMAT;

        /**
	    * GET List all local groups. params: page (int), count (int), format
	    * (string, 'xml', 'json', 'atom', or 'rss'), callback (string, JSON-P
	    * callback) [format is required]
	    */
	    public const String GROUPS_LIST_ALL_API = API_ROOT
			+ "statusnet/groups/list_all." + API_FORMAT;

        /**
	    * GET List the members of a given group. params: id (string, group ID or
	    * nickname), group_id (int), group_name (string), format (string, 'xml' or
	    * 'json'), callback (string, JSON-P callback) [format is required; must
	    * also include a param identifying a group]
	    */
	    public const String GROUPS_MEMBERSHIP_API = API_ROOT
			+ "statusnet/groups/membership." + API_FORMAT;

	    /**
	    * GET Determine whether a given user is a member of a given group. params:
	    * id (string, user ID or nickname), user_id (int), group_id (int),
	    * screen_name (string), group_name (string), format (string, 'xml' or
	    * 'json'), callback (string, JSON-P callback) [format is required; must
	    * also include a param identifying a user, and a param identifying a group]
	    */
	    public const String GROUPS_IS_MEMBER_API = API_ROOT
			+ "statusnet/groups/ismembership." + API_FORMAT;

	    /**
	    * Shows a tag's timeline. Similar to other timeline resources.
	    */
	    public const String TAGS_TIMELINE_API = API_ROOT
			+ "statusnet/tags/timeline." + API_FORMAT;

	    /**
	    * Twitpic-style endpoint for uploading an image. Returns a URL that can be
	    * used in a status update. Format post data as multipart/form-data.
	    */
	    public const String MEDIA_UPLOAD_API = API_ROOT + "media/upload."
			+ API_FORMAT;
        }
}
