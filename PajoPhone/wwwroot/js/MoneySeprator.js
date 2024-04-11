function reformat(){
    ans = []
    if($("#demo").val()!=""){
        var number = $("#demo").val().toString().replace(",","")
        var number_cop= number
        while(number>=1000){
            if (number%1000==0){
                ans.push("000")
            }else if(number%1000<10 && number_cop>=1000){
                ans.push("00"+number%1000)
            }else if(number%1000>=10 && number%1000<100&& number_cop>=1000){
                ans.push("0"+number%1000)
            }else{
                ans.push(number%1000)
            }

            number = (number-(number%1000))/1000

        }
        ans.push(number%1000)
        ans.reverse()

        console.log(ans.join());
        $("#demo").val(ans.join(","))
    }
}
$("#demo").keypress((e)=>{
    reformat()

})
$("#demo").change((e)=>{
    reformat()

})