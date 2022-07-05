$(function () {
 
    //Vertical form basic
    $('#wizard_vertical').steps({
        headerTag: 'h2',
        bodyTag: 'section',
        transitionEffect: 'slideLeft',
        stepsOrientation: 'vertical',
        onInit: function (event, currentIndex) {
            setButtonWavesEffect(event);
        },
        onStepChanged: function (event, currentIndex, priorIndex) {
            setButtonWavesEffect(event);
        },
        onStepChanging: function (event, currentIndex, newIndex) {
            //if (currentIndex > newIndex) { return true; }

            //if (currentIndex < newIndex) {
            //    form.find('.body:eq(' + newIndex + ') label.error').remove();
            //    form.find('.body:eq(' + newIndex + ') .error').removeClass('error');
            //}

            //form.validate().settings.ignore = ':disabled,:hidden';
            //return form.valid();
        },
        onFinished: function (event, currentIndex) {
            swal("Good job!", "Submitted!", "success");
        }
        



    });
    
});

function setButtonWavesEffect(event) {
    $(event.currentTarget).find('[role="menu"] li a').removeClass('waves-effect');
    $(event.currentTarget).find('[role="menu"] li:not(.disabled) a').addClass('waves-effect');
}