<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AD._default" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Home</title>
    <meta charset="utf-8">
    <meta name="keywords" content=<% =KEYWORDS%>/>
    <meta name="description" content=<%=DESCRIPTION %>/>
    <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <%=CSS %>
    <style type="text/css">
            .bannerDiv{position:relative;height:270px;overflow:hidden;}
            .bannerUl0,.bannerUl0 li{width:900px;height:280px; bottom:10px;}
            .bannerUl0{position:absolute;left:25px;top:0;}
            .bannerUl0 li{position:relative;float:left;display:none;}
            .bannerUl0 li.block{display:block;}
            .aNum{position:absolute;right:10px;bottom:10px;}
            .aNum a{width:15px;height:15px;line-height:15px;text-align:center;color:#ffffff;margin-right:2px;display:block;float:left;background-color:#6a747d;}
            .aNum a.aBanner{background-color:#d20000;}
     </style>
</head>
<body>
    <div class="dark-line"></div>
    <div id="wrapper">
         <%=DAOHANG %>
        <div class="inner clearfix">
            <div class="clearfix bottom-35">
                <a href="/" class="alignleft"><img src="images/content/logo.png" alt=""></a>
                <div class="description">
                    <h1><%=GONGSITITLE %></h1>
                    <p><%=GONGSITEXT %></p>
                </div>
            </div>
              <div  class="bannerDiv">
                        <ul class="bannerUl0">
                           <asp:Literal ID="titleimg" runat="server"></asp:Literal>
                        </ul>
              </div>
            <div class="divider-text bottom-50">
                <span>Recent Work<img src="images/dot.gif" alt=""><a href="portfolio.html">All Projects</a></span>
            </div>
            <ul id="portfolio" class="inner-960 bottom-15 clearfix">
                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-1.jpg" class="prettyPhoto zoom"></a> 
                        <a href="portfolio-single.html"></a>
                         <img src="images/content/img220x146-1.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Ut enim ad minima veniam</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-2.jpg" class="prettyPhoto zoom"></a> 
                        <a href="portfolio-single.html"></a> 
                        <img src="images/content/img220x146-2.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Consectetur adipisicing elit</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-3.jpg" class="prettyPhoto zoom"></a> 
                        <a href="portfolio-single.html"></a>
                         <img src="images/content/img220x146-3.jpg" alt=""></div>
                        <div class="proj-info">
                            <h4><a href="#">Vel illum qui dolorem</a></h4>
                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-4.jpg" class="prettyPhoto zoom"></a>
                         <a href="portfolio-single.html"></a> 
                         <img src="images/content/img220x146-4.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Quis nostrum exercitationem</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img">
                        <a href="images/content/img220x146-5.jpg" class="prettyPhoto zoom"></a> 
                        <a href="portfolio-single.html"></a> 
                        <img src="images/content/img220x146-5.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Ut enim ad minima veniam</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-6.jpg" class="prettyPhoto zoom"></a>
                        <a href="portfolio-single.html"></a>
                         <img src="images/content/img220x146-6.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Consectetur adipisicing elit</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-7.jpg" class="prettyPhoto zoom"></a>
                         <a href="portfolio-single.html"></a> 
                         <img src="images/content/img220x146-7.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Vel illum qui dolorem</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>

                <li class="col1-4">
                    <div class="project">
                        <div class="proj-img"><a href="images/content/img220x146-8.jpg" class="prettyPhoto zoom"></a> 
                        <a href="portfolio-single.html"></a> 
                        <img src="images/content/img220x146-8.jpg" alt=""></div>

                        <div class="proj-info">
                            <h4><a href="#">Quis nostrum exercitationem</a></h4>

                            <p>Et harum quidem rerum facilis est et expedita distinctio ...</p>
                        </div>
                    </div>
                </li>
            </ul>
			<div class="tweet bottom-50"></div>
            <div class="divider-text bottom-50">
                <span>Latest From The Blog<img src="images/dot.gif" alt=""><a href="blog.html">All Posts</a></span>
            </div>
            <ul id="recent-posts" class="inner-960 clearfix">
            <asp:Literal ID="new_list" runat="server"></asp:Literal>
            </ul>
        </div>

        <div class="open-close clearfix">
            <a href="#"></a>
        </div>
        <div class="footer-wrap">
            <div class="copyrigts clearfix">
                <span class="owner">Copyright 2012 = Poise = by 
                <a href="http://themeforest.net/user/fireform?ref=fireform">Fireform</a> All rights reserved</span>
                <div class="social">
                    <a href="#" class="twitter"></a>
                    <a href="#" class="facebook"></a>
                    <a href="#" class="forrstr"></a>
                    <a href="#" class="dribbble"></a> 
                    <a href="#" class="flickr"></a>
                    <a href="#" class="vimeo"></a>
                    <a href="#" class="linkedin"></a>
                </div>
            </div>
        </div>
    </div>

    <div class="dark-line">
        <a href="#" class="totop"></a>
    </div>
    <script type="text/javascript">
        var liNum = $('.bannerUl0 li').length, timer, playNum = 1;
        $(document).ready(function () {
            $('.bannerUl0').after('<div class="aNum"></div>');
            for (var i = 0; i < liNum; i++) {
                var aText = i + 1;
                if (i == 0) {
                    $('.aNum').append('<a href="javascript:void(0)" class="aBanner" onclick="changeBanner(' + i + ')">1</a>');
                }
                else {
                    $('.aNum').append('<a href="javascript:void(0)" onclick="changeBanner(' + i + ')">' + aText + '</a>');
                }
            }
            timer = setInterval('autoPlay()', 3000);
            $('.aNum a').hover(function () {
                clearInterval(timer);
            }, function () {

                timer = setInterval('autoPlay()', 3000);
            });
        });
        function changeBanner(num) {

            $('.bannerUl0 li').hide();
            $('.bannerUl0 li').eq(num).fadeIn(600);
            $('.aNum a').attr('class', '');
            $('.aNum a').eq(num).attr('class', 'aBanner');
            playNum = num + 1;
        }

        function autoPlay() {
            if (playNum == liNum) { playNum = 0; }
            changeBanner(playNum);

        }
</script>
<%=JAVASCRIPT%>
</body>
</html>
