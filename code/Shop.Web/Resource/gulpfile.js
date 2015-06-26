var gulp = require('gulp'),
   jshint=require('gulp-jshint'),
   uglify = require('gulp-uglify'),
   minifyCss=require('gulp-minify-css'),
   rename=require('gulp-rename'),
   concat=require('gulp-concat'),
   del=require('del'),
   browserSync=require('browser-sync');

gulp.task('clean',function(cb){
	del(['build/css','build/scripts'],cb)
})

gulp.task('build',['minify','minifycss'],function(){
   console.log("Good Job.")
})

gulp.task("default",['browser-sync'],function(){
	// gulp.start('minify','minifycss')
   console.log("Enjoy!")
})

gulp.task('minify', function () {
   gulp.src('scripts/*.js')
      .pipe(uglify())
      .pipe(rename({suffix:'.min'}))
      .pipe(gulp.dest('build/scripts'));
});

gulp.task('concat',function(){
   gulp.src('scripts/*.js')
   .pipe(uglify())
   .pipe(concat('site.js'))
   .pipe(gulp.dest('build/scripts'))
})

gulp.task("greet",function(){
	console.log('Hello World!');
})

gulp.task('jshint',function(){
	gulp.src('js/*.js').pipe(jshint());
})
gulp.task("minifycss",function(){
	gulp.src("css/*.css").pipe(minifyCss()).pipe(rename({suffix:'.min'})).pipe(gulp.dest('build/css'))
})

gulp.task("jshint",function(){
   gulp.src("scripts/*.js").pipe(jshint())
})

gulp.task('watch',function(){
   gulp.watch("**",function(event){
      console.log('Event type:'+event.type);
   })
})

gulp.task("browser-sync",function(){
   browserSync({
      files:["**",'!**.less'],
      server:{
         baseDir:"./"
      }
   });
})