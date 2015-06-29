var gulp = require('gulp'),
    browserSync=require('browser-sync'),
    concat=require('gulp-concat'),
    coffee=require('gulp-coffee'),
    del=require('del'),
    gutil=require('gulp-util'),
    jshint=require('gulp-jshint'),
    minifyCss=require('gulp-minify-css'),
    rename=require('gulp-rename'),
    runsequence=require('run-sequence'),
    sourcemaps=require("gulp-sourcemaps"),
    uglify = require('gulp-uglify');

gulp.task('clean',function(cb){
	del(['build/css','build/scripts'],cb)
});

gulp.task('build',['minify','minifycss'],function(){
   console.log("Good Job!")
});

gulp.task("default",['browser-sync','coffee'],function(){
	// gulp.start('minify','minifycss')
   console.log("Enjoy!")
});

gulp.task('minify', function () {
   gulp.src('./scripts/*.js')
      .pipe(sourcemaps.init())
      .pipe(uglify())
      .pipe(rename({suffix:'.min'}))
      .pipe(sourcemaps.write('../maps'))
      .pipe(gulp.dest('./scripts'));
});

gulp.task('concat',function(){
   gulp.src('./scripts/*.js')
   .pipe(uglify())
   .pipe(concat('site.js'))
   .pipe(gulp.dest('./build/scripts'))
});

gulp.task("greet",function(){
	console.log('Hello World!');
});

gulp.task('jshint',function(){
	gulp.src('./scripts/*.js').pipe(jshint());
});

gulp.task("minifycss",function(){
	gulp.src("./css/*.css").pipe(minifyCss()).pipe(rename({suffix:'.min'})).pipe(gulp.dest('./css/'))
});

gulp.task('coffee',function(){
   gulp.src('coffee/*.coffee')
   .pipe(sourcemaps.init())
   .pipe(coffee({bare:true}).on('error',gutil.log))
   .pipe(sourcemaps.write('../maps'))
   .pipe(gulp.dest('./scripts'))
});

gulp.task('watch',function(){
   gulp.watch("./coffee/**.coffee",['coffee'])
});

gulp.task("browser-sync",function(){
   browserSync({
      files:["**",'!**.less','!**.coffee'],
      server:{
         baseDir:"./"
      }
      // ,port:2015
   });
});