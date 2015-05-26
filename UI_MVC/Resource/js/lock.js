var Lock = function () {

    return {
        //main function to initiate the module
        init: function () {

            $.backstretch([
               "/Resource/image/bg/1.jpg",
               "/Resource/image/bg/2.jpg",
               "/Resource/image/bg/3.jpg",
               "/Resource/image/bg/4.jpg"
            ], {
                fade: 1000,
                duration: 8000
            });

            var options = {
                success: function (res) {
                    if (res.Message != 'OK') {
                        $('.lab-error').show();
                    } else {
                        history.go(-1);// ∑µªÿ…œ“ª“≥
                    }
                },
                dataType: 'json',
                type: 'post'
            };

            $('.form-unlock').ajaxForm(options);
        }

    };

}();