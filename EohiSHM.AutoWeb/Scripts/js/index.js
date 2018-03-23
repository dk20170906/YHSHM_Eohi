/**
 * Created by Administrator on 2017/2/28.
 */
//合作机构轮播
var oDiv = document.getElementById('pBox');
var oul = oDiv.getElementsByTagName('ul')[0];
var ali = oul.getElementsByTagName('li');
var spa = -2;
oul.innerHTML=oul.innerHTML+oul.innerHTML;
oul.style.width=ali[0].offsetWidth*ali.length+'px';
function move(){
    if(oul.offsetLeft<-oul.offsetWidth/2){
        oul.style.left='0';
    }
    if(oul.offsetLeft>0){
        oul.style.left=-oul.offsetWidth/2+'px'
    }
    oul.style.left=oul.offsetLeft+spa+'px';
}
var timer = setInterval(move,100);

oDiv.onmousemove=function(){clearInterval(timer);};
oDiv.onmouseout=function(){timer = setInterval(move,100)};
document.getElementsByClassName('p-left')[0].onclick = function(){
    spa=-2;
};
document.getElementsByClassName('p-right')[0].onclick = function(){
    spa=2;
}
//视频播放效果
var player=document.getElementById("player");
var playOrPause=document.getElementById("playOrPause");
var mask=document.getElementsByClassName('mask');
playOrPause.onclick=function(){
    player.play();	//播放影片
    player.controls=true;
    mask[0].style.display='none';
}
player.onpause=function(){
    mask[0].style.display='inline-block';
}
player.onplay=function(){
    mask[0].style.display='none';
}
//典型案例划入显示效果
$('#effect .img').mouseover(function(){
    $(this).children(".overlay").show();
})
$('#effect .img').mouseleave(function(){
    $(this).children(".overlay").hide();
})