BEGIN_FUNCTION_MAP
    .Func,선옵복수계좌복수종목정상주문,t5009,base21=SONBT712,headtype=B;
    BEGIN_DATA_MAP
    t5009InBlock,기본입력,input;
    begin
        레코드갯수			     ,reccnt   		,reccnt   	   ,long    ,5	    ;
        통신매체코드			 ,tongsingb		,tongsingb	   ,char    ,2	    ;
        레코드갯수1			     ,reccnt1  		,reccnt1   	   ,long    ,5	    ;
    end
    t5009InBlock1,기본입력1,input,occurs;
    begin
        계좌번호			     ,accno   		,accno   	   ,char    ,20     ;
        입력비밀번호			 ,passwd  		,passwd  	   ,char    ,8	    ;
        선물옵션종목번호		 ,expcode 		,expcode 	   ,char    ,32     ;
        매매구분			     ,mmgubun 		,mmgubun 	   ,char    ,1	    ;
        선물옵션호가유형코드	 ,hogagb  		,hogagb  	   ,char    ,2	    ;
        주문가				     ,price   		,price   	   ,double  ,13.2   ;
        주문수량			     ,qty     		,qty     	   ,long    ,16     ;
        운용지시번호			 ,opjisino		,opjisino	   ,char    ,12     ;
    end
    t5009OutBlock,출력,output;
    begin
        레코드갯수			     ,reccnt   		,reccnt   	   ,long    ,5	    ;
        통신매체코드			 ,tongsingb		,tongsingb	   ,char    ,2	    ;
    end
    t5009OutBlock1,출력1,output,occurs;
    begin
        계좌번호			     ,accno   		,accno   	   ,char    ,20     ;
        입력비밀번호			 ,passwd  		,passwd  	   ,char    ,8	    ;
        선물옵션종목번호		 ,expcode 		,expcode 	   ,char    ,32     ;
        매매구분			     ,mmgubun 		,mmgubun 	   ,char    ,1	    ;
        선물옵션호가유형코드	 ,hogagb  		,hogagb  	   ,char    ,2	    ;
        주문가				     ,price   		,price   	   ,double  ,13.2   ;
        주문수량			     ,qty     		,qty     	   ,long    ,16     ;
        운용지시번호			 ,opjisino		,opjisino	   ,char    ,12     ;
    end
    t5009OutBlock2,출력2,output,occurs;
    begin
        dummy주문번호			 ,dummyordno    ,dummyordno    ,long    ,3      ;
        주문번호			     ,ordno   		,ordno   	   ,long    ,7      ;
        메시지코드			     ,msgcode 		,msgcode 	   ,char    ,4	    ;
        메시지내용			     ,msg     		,msg     	   ,char    ,100    ;
        처리시각			     ,proctime		,proctime	   ,char    ,9	    ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
