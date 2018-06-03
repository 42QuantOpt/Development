BEGIN_FUNCTION_MAP
    .Func,거래소 선물대용매도(t5012),t5012,base21=SONAT013,headtype=B;
    BEGIN_DATA_MAP
    t5012InBlock,기본입력,input;
    begin
        레코드갯수			     ,reccnt     		,reccnt     	   ,long    ,5	    ;
        계좌번호			     ,accno      		,accno      	   ,char    ,20     ;
        입력비밀번호		     ,passwd     		,passwd     	   ,char    ,8	    ;
        선물계좌번호		     ,futaccno   		,futaccno   	   ,char    ,20     ;
        선물시장구분		     ,futmarketgb		,futmarketgb	   ,char    ,1	    ;
        종목번호			     ,expcode    		,expcode    	   ,char    ,12     ;
        선물대용구분		     ,futdaegb   		,futdaegb   	   ,char    ,1	    ;
        주문수량			     ,qty        		,qty        	   ,long    ,16     ;
        주문가				     ,price      		,price      	   ,double  ,13.2   ;
        호가유형코드		     ,hogagb     		,hogagb     	   ,char    ,2	    ;
        주문조건구분		     ,ordcondgb      	,ordcondgb         ,char    ,1	    ;
        통신매체코드		     ,tongsingb  		,tongsingb  	   ,char    ,2	    ;
    end
    t5012OutBlock,기본출력,output;
    begin
        레코드갯수			     ,reccnt     		,reccnt     	   ,long    ,5	    ;
        계좌번호			     ,accno      		,accno      	   ,char    ,20     ;
        입력비밀번호		     ,passwd     		,passwd     	   ,char    ,8	    ;
        선물계좌번호		     ,futaccno   		,futaccno   	   ,char    ,20     ;
        선물시장구분		     ,futmarketgb		,futmarketgb	   ,char    ,1	    ;
        종목번호			     ,expcode    		,expcode    	   ,char    ,12     ;
        선물대용구분		     ,futdaegb   		,futdaegb   	   ,char    ,1	    ;
        주문수량			     ,qty        		,qty        	   ,long    ,16     ;
        주문가				     ,price      		,price      	   ,double  ,13.2   ;
        호가유형코드		     ,hogagb     		,hogagb     	   ,char    ,2	    ;
        주문조건구분		     ,ordcondgb      	,ordcondgb         ,char    ,1	    ;
        통신매체코드		     ,tongsingb  		,tongsingb  	   ,char    ,2	    ;
    end
    t5012OutBlock1,기본출력1,output;
    begin
        레코드갯수			     ,reccnt		    ,reccnt	           ,long    ,5	    ;
        주문번호			     ,ordno 		    ,ordno 	           ,long    ,10      ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
