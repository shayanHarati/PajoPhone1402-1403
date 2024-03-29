let categories = $("#categories")
let categoryChildren =categories.children()
categoryChildren.each((categoryChildIndex)=>{
    // debugger; 
    var categoryChild = categoryChildren[categoryChildIndex]
    var categoryChildLevel = $(categoryChild).attr("level")
    if((+categoryChildLevel)>0){
        // debugger;
        for(var dta =0; dta<$(categoryChildren[categoryChildLevel]).children().length;dta++){
            // debugger;
            // console.log(dta);
            let parentLevel = +categoryChildLevel -1
            // console.log("div.ul[level='"+0+"'] details[id='"+$($(categoryChild).children()[0]).attr("parent-id")+"']");
            let parent =$("div.ul[level='"+0+"'] details[id='"+$($(categoryChild).children()[dta]).attr("parent-id")+"']")
            
            var div = document.createElement("div")
            // $(div).addClass("ul").attr("level",categoryChildLevel)
            var detail = document.createElement("details")
            // console.log($($($(categoryChild).children())[dta]));
            $(detail).attr("id",$($(categoryChild).children()[dta]).attr("id")).attr("parent-id",$($(categoryChild).children()[dta]).attr("parent-id")).append($($($(categoryChild).children())[dta]).children())
            $(categoryChildren[1]).children().remove(":nth-child("+0+")")
            $(detail).css("padding-right",categoryChildLevel+"rem")
            $(detail).addClass("m-2")
            $(parent).append(detail)
            
        
        }
        // debugger;
            $(categoryChildren[categoryChildLevel]).empty()
            
    }
    
})

