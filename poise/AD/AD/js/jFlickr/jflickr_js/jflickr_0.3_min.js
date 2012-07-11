/*----------------------------------------
* jFlickr 0.3 min
------------------------------------------
* Autor			Lukas Rydygel
* Version		0.3 min
* Date			18.04.2010
* Copyright		2010 - Lukas Rydygel
* Agency		---
----------------------------------------*/

(function($){$.jFlickr=function(settings){settings=jQuery.extend({pictures:1,positions:'',flickrId:'',tags:'',tagMode:'all',grabSize:'auto',random:false,helperTags:'tag',helperHiddenTags:'hidden',callback:function(){}},settings);settings.print=false;$('body').jFlickr(settings);};$.fn.jFlickr=function(settings){settings=jQuery.extend({print:true,pictures:1,positions:'',flickrId:'',tags:'',tagMode:'all',grabSize:'auto',width:'',height:'',random:false,helper:'',helperTags:'tag',helperHiddenTags:'hidden',link:true,callback:function(){}},settings);$(this).each(function(){initPlugin(this);});var sizes=[100,240,500,1024];var sources=['_t.jpg','_m.html','.jpg','_b.jpg'];function initPlugin(matchedObj){var pointer=$('.jflickr-container').length;pointer++;(settings.print)?createHtml(matchedObj,pointer):'';getImages(pointer);}
function createHtml(matchedObj,pointer){$(matchedObj).wrap('<div id="jflickr_'+pointer+'" class="jflickr-container clearfix" />');$(matchedObj).before('<div class="jflickr-images clearfix" />');$('#jflickr_'+pointer+' .jflickr-images').addClass(settings.helper);}
function fillRandom(positions,max){var start=(positions[0]=='')?0:positions.length;for(var i=start;i<settings.pictures;i++){var rand=getRandom(0,max-1);while($.inArray(rand,positions)!=-1){rand=getRandom(0,max-1);}
positions[i]=rand;}
return positions;}
function getRandom(min,max){return Math.floor(Math.random()*(max-min+1))+min;}
function getSize(item){var size={};size.width=$(item).find('img').attr('width');size.height=$(item).find('img').attr('height');var ratio=size.width/size.height;switch(settings.grabSize){case'thumb':size.max=sizes[0];break;case'middle':size.max=sizes[1];break;case'normal':size.max=sizes[2];break;case'big':size.max=sizes[3];break;case'auto':if(settings.width!=''||settings.height!=''){size.max=sizes[3];if(settings.width==''){var autoWidth=settings.height*ratio;var autoHeight=settings.height;}else if(settings.height==''){var autoWidth=settings.width;var autoHeight=settings.width/ratio;}else{if(ratio>1){var autoWidth=settings.width*ratio;var autoHeight=settings.width;}else if(ratio<1){var autoWidth=settings.height;var autoHeight=settings.height*ratio;}else{var autoWidth=settings.height;var autoHeight=settings.height;}}
for(var i=0;i<sizes.length;i++){if(autoWidth<=sizes[i]&&autoHeight<=sizes[i]){size.max=sizes[i];break;}}}else{size.max=sizes[1];}
break;}
size.boxWidth=settings.width;size.boxHeight=settings.height;if(size.width>size.height){var scale=size.width/size.max;size.width=size.max;size.height/=scale;}else{var scale=size.height/size.max;size.width/=scale;size.height=size.max;}
if(settings.width!=''&&settings.height!=''){var scale=new Object;scale.width=size.width/settings.width;scale.height=size.height/settings.height;if(scale.width>scale.height){size.width='';size.height=settings.height;}else{size.width=settings.width;size.height='';}}else if(settings.width!=''&&settings.height==''){size.width=settings.width;size.height='';size.boxWidth=settings.width;size.boxHeight='';}else if(settings.width==''&&settings.height!=''){size.width='';size.height=settings.height;size.boxWidth='';size.boxHeight=settings.height;}
return size;}
function trim(s,x){while(s.substring(0,1)==x){s=s.substring(1,s.length);}
while(s.substring(s.length-1,s.length)==x){s=s.substring(0,s.length-1);}
return s;}
function getTags(pointer){var tags=[];$('#jflickr_'+pointer).find('.'+settings.helperTags).each(function(i){tags[i]=$(this).text();});var j=tags.length
$('#jflickr_'+pointer).find('.'+settings.helperHiddenTags).each(function(i){tags[j+i]=$(this).text();$(this).remove();});return trim(settings.tags+','+tags.join(','),',');}
function getPositions(items){var positions=[];settings.pictures=(settings.pictures>items)?items:settings.pictures;if(settings.positions!=''){for(var i=0;i<settings.positions.length;i++){settings.positions[i]--;}
positions=settings.positions;}
settings.pictures=(settings.pictures<positions.length)?positions.length:settings.pictures;return(settings.pictures>positions.length&&positions.length>0||settings.random)?fillRandom(positions,items):positions;}
function grabImage(image,item){var ratio=$(item).find('img').attr('width')/$(item).find('img').attr('height');switch(settings.grabSize){case'thumb':return image.replace('_m.html',sources[0]);break;case'middle':return image;break;case'normal':return image.replace('_m.html',sources[2]);break;case'big':return image.replace('_m.html',sources[3]);break;case'auto':if(settings.width!=''||settings.height!=''){if(settings.width==''){var autoWidth=settings.height*ratio;var autoHeight=settings.height;}else if(settings.height==''){var autoWidth=settings.width;var autoHeight=settings.width/ratio;}else{if(ratio>1){var autoWidth=settings.width*ratio;var autoHeight=settings.width;}else if(ratio<1){var autoWidth=settings.height;var autoHeight=settings.height*ratio;}else{var autoWidth=settings.height;var autoHeight=settings.height;}}
for(var i=0;i<sizes.length;i++){if(autoWidth<=sizes[i]&&autoHeight<=sizes[i]){return image.replace('_m.html',sources[i]);}}
return image;}
return image;break;}
return false;}
function getImages(pointer){var tags=getTags(pointer);var feedUri='http://api.flickr.com/services/feeds/photos_public.gne?ids='+settings.flickrId+'&tags='+tags+'&tagmode='+settings.mode+'&format=json&jsoncallback=?';$.getJSON(feedUri,function(data){var items=data.items.length;if(items>0){var positions=getPositions(items);var counter=0;var items=[];$.each(data.items,function(i,item){if($.inArray(i,positions)!=-1||positions.length==0){item.media=grabImage(item.media.m,item.description);var size=getSize(item.description);items.push({'title':item.title,'link':item.link,'media':item.media,'size':{'width':Math.round(size.width),'height':Math.round(size.height)},'date':{'taken':item.date_taken,'published':item.published},'author':{'name':item.author,'id':item.author_id},'tags':item.tags});(settings.print)?printItem(item,pointer,counter,size):'';counter++;}
if(counter>=settings.pictures){(settings.print)?settings.callback($('#jflickr_'+pointer+' .jflickr-images img'),items):settings.callback(items);return false;}});}});}
function printItem(item,pointer,counter,size){var id=counter+1;$('#jflickr_'+pointer+' .jflickr-images').append('<div class="jflickr-image jflickr-image_'+id+'"><img src="'+item.media+'" alt="'+item.title+' - '+item.tags+'" /></div>');(settings.link)?$('#jflickr_'+pointer+' .jflickr-images .jflickr-image_'+id+' img').wrap('<a href="'+item.link+'" />'):'';(size.boxWidth!='')?$('#jflickr_'+pointer+' .jflickr-images .jflickr-image_'+id).width(size.boxWidth):'';(size.boxHeight!='')?$('#jflickr_'+pointer+' .jflickr-images .jflickr-image_'+id).height(size.boxHeight):'';(size.width!='')?$('#jflickr_'+pointer+' .jflickr-images .jflickr-image_'+id+' img').width(size.width):'';(size.height!='')?$('#jflickr_'+pointer+' .jflickr-images .jflickr-image_'+id+' img').height(size.height):'';}};})(jQuery);