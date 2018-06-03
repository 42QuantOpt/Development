BEGIN_FUNCTION_MAP
    .Func,주문가능수량/증거금(t6024),t6024,base21=SONBQ103,headtype=B;
    BEGIN_DATA_MAP
    t6024InBlock,기본입력,input;
    begin
        레코드갯수			     ,reccnt  		    ,reccnt  	       ,long    ,5	    ;
        계좌번호			     ,accno   		    ,accno   	       ,char    ,20     ;
        입력비밀번호			 ,passwd  		    ,passwd  	       ,char    ,8	    ;
        금액수량구분			 ,gubun   		    ,gubun   	       ,char    ,1	    ;
        선물옵션호가유형코드	 ,fohogagb		    ,fohogagb	       ,char    ,2	    ;
        주문금액			     ,ordamt  		    ,ordamt  	       ,long    ,16     ;
    BEGIN_DATA_MAP
    t6024InBlock1,기본입력1,input;
    begin
        레코드갯수2			     ,reccnt2  		    ,reccnt2  	       ,long    ,5	    ;
    end
    t6024InBlock2,기본입력2,input,occurs;
    begin
        선물옵션종목번호		 ,focodeno		    ,focodeno	       ,char    ,32     ;
        매매구분			     ,memegb  		    ,memegb  	       ,char    ,1	    ;
        주문가				     ,price   		    ,price   	       ,double  ,13.2   ;
        주문수량			     ,ordqty  		    ,ordqty  	       ,long    ,16     ;
    end
    t6024OutBlock,기본출력,output;
    begin
        레코드갯수			     ,reccnt  		    ,reccnt  	       ,long    ,5	    ;
        계좌번호			     ,accno   		    ,accno   	       ,char    ,20     ;
        입력비밀번호			 ,passwd  		    ,passwd  	       ,char    ,8	    ;
        금액수량구분			 ,gubun   		    ,gubun   	       ,char    ,1	    ;
        선물옵션호가유형코드	 ,fohogagb		    ,fohogagb	       ,char    ,2	    ;
        주문금액			     ,ordamt  		    ,ordamt  	       ,long    ,16     ;
    end
    t6024OutBlock1,기본출력1,output,occurs;
    begin
        선물옵션종목번호		 ,focodeno		    ,focodeno	       ,char    ,32     ;
        매매구분			     ,memegb  		    ,memegb  	       ,char    ,1	    ;
        주문가				     ,price   		    ,price   	       ,double  ,13.2   ;
        주문수량			     ,ordqty  		    ,ordqty  	       ,long    ,16     ;
    end
    t6024OutBlock2,기본출력2,output;
    begin
        레코드갯수			     ,reccnt       		,reccnt       	   ,long    ,5	    ;
        계좌명				     ,accname      		,accname      	   ,char    ,40     ;
        주문일				     ,date         		,date         	   ,char    ,8	    ;
        주문가능금액			 ,ordnamtqty   		,ordnamtqty   	   ,long    ,16     ;
        현금주문가능금액		 ,ordcashamt   		,ordcashamt   	   ,long    ,16     ;
        대용주문가능금액		 ,orddyamt     		,orddyamt     	   ,long    ,16     ;
        소요선물증거금액		 ,syfpriceamt  		,syfpriceamt  	   ,long    ,16     ;
        소요선물현금증거금액	 ,syfcashamt   		,syfcashamt   	   ,long    ,16     ;
        소요선물대용증거금액	 ,syfdyamt     		,syfdyamt     	   ,long    ,16     ;
        소요옵션증거금액		 ,syoptpriceamt		,syoptpriceamt	   ,long    ,16     ;
        소요옵션현금증거금액	 ,syoptchashamt		,syoptchashamt	   ,long    ,16     ;
        소요옵션대용증거금액	 ,syoptdyamt   		,syoptdyamt   	   ,long    ,16     ;
        소요스프레드증거금액	 ,syspdpriceamt		,syspdpriceamt	   ,long    ,16     ;
        소요스프레드현금증거금액 ,syspdcashamt 		,syspdcashamt 	   ,long    ,16     ;
        소요스프레드대용증거금액 ,syspddyamt   		,syspddyamt   	   ,long    ,16     ;
        소요증거금액			 ,sypriceamt   		,sypriceamt   	   ,long    ,16     ;
        소요현금증거금액		 ,sychashamt   		,sychashamt   	   ,long    ,16     ;
        소요대용증거금액		 ,sydyamt      		,sydyamt      	   ,long    ,16     ;
        증거금잔액			     ,namamt       		,namamt       	   ,long    ,16     ;
        현금증거금잔액			 ,cashnamamt   		,cashnamamt   	   ,long    ,16     ;
        대용증거금잔액			 ,dynamamt     		,dynamamt     	   ,long    ,16     ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
