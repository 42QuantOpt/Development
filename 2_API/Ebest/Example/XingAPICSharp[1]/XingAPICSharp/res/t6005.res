BEGIN_FUNCTION_MAP
    .Func,증거금율별주문가능금액조회(t6005),t6005,base21=SONAQ201,headtype=B;
    BEGIN_DATA_MAP
    t6005InBlock,기본입력,input;
    begin
        레코드갯수			                 ,reccnt		    ,reccnt		           ,long    ,5	    ;
        매매구분			                 ,memegb 		    ,memegb  	           ,char    ,1	    ;
        계좌번호			                 ,accno  		    ,accno   	           ,char    ,20     ;
        입력비밀번호			             ,passwd 		    ,passwd  	           ,char    ,8	    ;
        종목번호			                 ,expcode		    ,expcode 	           ,char    ,12     ;
        주문가				                 ,hopemesu  		,hopemesu   	       ,double  ,13.2   ;
        통신매체코드			             ,mechegb		    ,mechegb 	           ,char    ,2	    ;
    end
    t6005OutBlock,기본출력,output;
    begin
        레코드갯수			                 ,reccnt		    ,reccnt		           ,long    ,5	    ;
        매매구분			                 ,memegb  		    ,memegb  	           ,char    ,1	    ;
        계좌번호			                 ,accno   		    ,accno   	           ,char    ,20     ;
        입력비밀번호			             ,passwd  		    ,passwd  	           ,char    ,8	    ;
        종목번호			                 ,expcode 		    ,expcode 	           ,char    ,12     ;
        주문가				                 ,hopemesu   		,hopemesu   	       ,double  ,13.2   ;
        통신매체코드			             ,mechegb 		    ,mechegb 	           ,char    ,2	    ;
    end
    t6005OutBlock1,기본출력1,output;
    begin
        레코드갯수			                 ,reccnt		    ,reccnt		    	   ,long    ,5	    ;
        계좌명				                 ,accname      		,accname      		   ,char    ,40     ;
        종목명				                 ,codename     		,codename     		   ,char    ,40     ;
        예수금				                 ,depoamt      		,depoamt      		   ,long    ,16     ;
        대용금액			                 ,daeamt       		,daeamt       		   ,long    ,16     ;
        신용담보재사용금액		             ,cdamreuse    		,cdamreuse    		   ,long    ,16     ;
        현금주문가능금액		             ,cashordamt      	,cashordamt       	   ,long    ,16     ;
        대용주문가능금액		             ,orddae       		,orddae       		   ,long    ,16     ;
        현금증거금액			             ,margincash   		,margincash   		   ,long    ,16     ;
        대용증거금액			             ,margindae    		,margindae    		   ,long    ,16     ;
        거래소금액			                 ,kospiamt     		,kospiamt     		   ,long    ,16     ;
        코스닥금액			                 ,kosdaqamt    		,kosdaqamt    		   ,long    ,16     ;
        추정예수금(D+1) 		             ,d1cash       		,d1cash       		   ,long    ,16     ;
        추정예수금(D+2) 		             ,d2cash       		,d2cash       		   ,long    ,16     ;
        출금가능금액			             ,chulcanamt   		,chulcanamt   		   ,long    ,16     ;
        미수금액			                 ,misuamt      		,misuamt      		   ,long    ,16     ;
        수수료율			                 ,susuryorate  		,susuryorate  		   ,double  ,11.8   ;
        추가징수금액			             ,addchamt     		,addchamt     		   ,long    ,16     ;
        재사용대상금액			             ,resuseamt    		,resuseamt    		   ,long    ,16     ;
        현금재사용대상금액		             ,cashresuseamt		,cashresuseamt		   ,long    ,16     ;
        이용사증거금률			             ,usemarginrate		,usemarginrate		   ,double  ,7.4    ;
        대용재사용대상금액		             ,daereuseamt  		,daereuseamt  		   ,long    ,16     ;
        종목증거금률			             ,daeresuseamt 		,daeresuseamt 		   ,double  ,7.4    ;
        계좌증거금률			             ,charate      		,charate      		   ,double  ,7.4    ;
        거래증거금률			             ,marginrate   		,marginrate   		   ,double  ,7.4    ;
        수수료				                 ,susuryo      		,susuryo      		   ,long    ,16     ;
        증거금률50퍼센트주문가능금액	     ,ordamt50		    ,ordamt50			   ,long    ,16     ;
        증거금률50퍼센트주문가능수량         ,ordcashqty50		,ordcashqty50		   ,long    ,16     ;
        증거금률30퍼센트주문가능금액	     ,ordamt30		    ,ordamt30			   ,long    ,16     ;
        증거금률30퍼센트주문가능수량	     ,ordqty30		    ,ordqty30			   ,long    ,16     ;
        증거금률40퍼센트주문가능금액	     ,ordamt40		    ,ordamt40			   ,long    ,16     ;
        증거금률40퍼센트주문가능수량	     ,ordqty40		    ,ordqty40			   ,long    ,16     ;
        증거금률100퍼센트주문가능금액	     ,ordamt100		    ,ordamt100			   ,long    ,16     ;
        증거금률100퍼센트주문가능수량        ,ordqty100		    ,ordqty100			   ,long    ,16     ;
        증거금률100퍼센트현금주문가능금액    ,ordcashamt100		,ordcashamt100		   ,long    ,16     ;
        증거금률100퍼센트현금주문가능수량    ,ordcashqty100		,ordcashqty100		   ,long    ,16     ;
        증거금률20퍼센트재사용가능금액	     ,reamt20		    ,reamt20		       ,long    ,16     ;
        증거금률30퍼센트재사용가능금액	     ,reamt30		    ,reamt30		       ,long    ,16     ;
        증거금률40퍼센트재사용가능금액	     ,reamt40		    ,reamt40		       ,long    ,16     ;
        증거금률100퍼센트재사용가능금액      ,reamt100		    ,reamt100			   ,long    ,16     ;
        주문가능수량			             ,memeqty		    ,memeqty		       ,long    ,16     ;
        주문가능금액			             ,ordamt		    ,ordamt		    	   ,long    ,16     ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
